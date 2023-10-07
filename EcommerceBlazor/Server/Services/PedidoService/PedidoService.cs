using System.Collections.Generic;
using System.Security.Claims;

namespace EcommerceBlazor.Server.Services.PedidoService
{
    public class PedidoService : IPedidoService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly ICarrinhoService _carrinhoService;
        private readonly IAuthService _authService;

        public PedidoService(EcommerceBlazorContext context, ICarrinhoService carrinhoService, IAuthService authService)
        {
            _context = context;
            _carrinhoService = carrinhoService;
            _authService = authService;
        }

        public async Task<ServiceResponse<bool>> CriarPedido()
        {
            var produtos = (await _carrinhoService.GetProdutosCarrinhoDB()).Data;
            decimal precoTotal = 0;

            produtos.ForEach(produto => precoTotal += produto.Preco * produto.Quantidade);

            var itensPedido = new List<ItemPedido>();

            produtos.ForEach(produto => itensPedido.Add(new ItemPedido
            {
                ProdutoId = produto.ProdutoId,
                TipoProdutoId = produto.TipoProdutoId,
                Quantidade = produto.Quantidade,
                PrecoTotal = produto.Preco * produto.Quantidade,
            }));

            var pedido = new Pedido
            {
                UsuarioId = _authService.GetUsuarioId(),
                DataPedido = DateTime.Now,
                PrecoTotal = precoTotal,
                Itens = itensPedido
            };

            _context.Pedido.Add(pedido);

            _context.ItemCarrinho.RemoveRange(_context.ItemCarrinho.Where(x => x.UsuarioId == _authService.GetUsuarioId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<PedidoDetalhesResponse>> GetDetalhesPedido(int pedidoId)
        {
            var response = new ServiceResponse<PedidoDetalhesResponse>();

            var pedido = await _context.Pedido
                .Include(o => o.Itens)
                .ThenInclude(oi => oi.Produto)
                .Include(o => o.Itens)
                .ThenInclude(oi => oi.TipoProduto)
                .Where(o => o.UsuarioId == _authService.GetUsuarioId() && o.Pedido_ID == pedidoId)
                .OrderByDescending(o => o.DataPedido)
                .FirstOrDefaultAsync();

            if (pedido == null)
            {
                response.Success = false;
                response.Message = "Pedido não encontrado!";
                return response;
            }

            var pedidoDetalhes = new PedidoDetalhesResponse
            {
                DataPedido = pedido.DataPedido,
                PrecoTotal = pedido.PrecoTotal,
                Itens = new List<ItemPedidoDetalhesReponse>()
            };

            pedido.Itens.ForEach(item => pedidoDetalhes.Itens.Add(new ItemPedidoDetalhesReponse
            {
                ProdutoId = item.ProdutoId,
                UrlImagemProduto = item.Produto.UrlImagem,
                TipoProduto = item.TipoProduto.Nome,
                Quantidade = item.Quantidade,
                NomeProduto = item.Produto.Nome,
                PrecoTotal = item.PrecoTotal
            }));

            response.Data = pedidoDetalhes;

            return response;
        }

        public async Task<ServiceResponse<List<PedidoOverviewResponse>>> GetPedidos()
        {
            var response = new ServiceResponse<List<PedidoOverviewResponse>>();

            var pedidos = await _context.Pedido
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .Where(x => x.UsuarioId == _authService.GetUsuarioId())
                .OrderByDescending(o => o.DataPedido)
                .ToListAsync();

            var pedidosResponse = new List<PedidoOverviewResponse>();

            pedidos.ForEach(x => pedidosResponse.Add(new PedidoOverviewResponse
            {
                PedidoId = x.Pedido_ID,
                DataPedido = x.DataPedido,
                PrecoTotal = x.PrecoTotal,
                NomeProduto = x.Itens.Count > 1 ? 
                                    $"{x.Itens.First().Produto.Nome} e {x.Itens.Count - 1} mais..." :
                                    x.Itens.First().Produto.Nome,
                UrlImagemProduto = x.Itens.First().Produto.UrlImagem
            }));

            response.Data = pedidosResponse;

            return response;
        }
    }
}
