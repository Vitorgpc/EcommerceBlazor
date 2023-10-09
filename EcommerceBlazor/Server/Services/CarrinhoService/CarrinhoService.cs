using System.Security.Claims;

namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly IAuthService _authService;

        public CarrinhoService(EcommerceBlazorContext context, IAuthService authService)
        { 
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinho(List<ItemCarrinho> itensCarrinho)
        {
            var resultado = new ServiceResponse<List<CarrinhoProdutoResponse>>
            {
                Data = new List<CarrinhoProdutoResponse>()
            };

            foreach (var item in itensCarrinho)
            {
                var produto = await _context.Produto.Where(x => x.Produto_ID == item.ProdutoId).FirstOrDefaultAsync();

                if (produto == null)
                {
                    continue;
                }

                var variante = await _context.ProdutoVariante
                    .Where(x => x.ProdutoId == item.ProdutoId &&
                           x.TipoProdutoId == item.TipoProdutoId)
                    .Include(v => v.TipoProduto)
                    .FirstOrDefaultAsync();

                if (variante == null)
                {
                    continue;
                }

                var produtoCarrinho = new CarrinhoProdutoResponse
                {
                    ProdutoId = produto.Produto_ID,
                    Nome = produto.Nome,
                    UrlImagem = produto.UrlImagem,
                    Preco = variante.Preco,
                    TipoProduto = variante.TipoProduto.Nome,
                    TipoProdutoId = variante.TipoProdutoId,
                    Quantidade = item.Quantidade
                };

                resultado.Data.Add(produtoCarrinho);
            }

            return resultado;
        }

        public async Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GravarItensCarrinho(List<ItemCarrinho> itensCarrinho)
        {
            itensCarrinho.ForEach(c => c.UsuarioId = _authService.GetUsuarioId());
            _context.ItemCarrinho.AddRange(itensCarrinho);

            await _context.SaveChangesAsync();

            var itens = await _context.ItemCarrinho.Where(x => x.UsuarioId == _authService.GetUsuarioId()).ToListAsync();

            return await GetProdutosCarrinhoDB();
        }

        public async Task<ServiceResponse<int>> GetQuantidadeItens()
        {
            var count = (await _context.ItemCarrinho.Where(x => x.UsuarioId == _authService.GetUsuarioId()).ToListAsync()).Count;
            
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinhoDB(int? usuarioId = null)
        {
            if (usuarioId == null)
            {
                usuarioId = _authService.GetUsuarioId();
            }

            return await GetProdutosCarrinho(await _context.ItemCarrinho
                .Where(x => x.UsuarioId == usuarioId).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AdicionarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            itemCarrinho.UsuarioId = _authService.GetUsuarioId();

            var mesmoItem = await _context.ItemCarrinho.FirstOrDefaultAsync(x => 
                x.ProdutoId == itemCarrinho.ProdutoId && 
                x.TipoProdutoId == itemCarrinho.TipoProdutoId &&
                x.UsuarioId == itemCarrinho.UsuarioId);

            if (mesmoItem == null)
            {
                _context.ItemCarrinho.Add(itemCarrinho);
            }
            else
            {
                mesmoItem.Quantidade += itemCarrinho.Quantidade;
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> AtualizarQuantidade(ItemCarrinho itemCarrinho)
        {
            var dbItemCarrinho = await _context.ItemCarrinho.FirstOrDefaultAsync(x =>
                x.ProdutoId == itemCarrinho.ProdutoId &&
                x.TipoProdutoId == itemCarrinho.TipoProdutoId &&
                x.UsuarioId == _authService.GetUsuarioId());

            if (dbItemCarrinho == null)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Item não existe!" };
            }

            dbItemCarrinho.Quantidade = itemCarrinho.Quantidade;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoverItemCarrinho(int produtoId, int tipoProdutoId)
        {
            var dbItemCarrinho = await _context.ItemCarrinho.FirstOrDefaultAsync(x =>
                x.ProdutoId == produtoId &&
                x.TipoProdutoId == tipoProdutoId &&
                x.UsuarioId == _authService.GetUsuarioId());

            if (dbItemCarrinho == null)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Item não existe!" };
            }

            _context.ItemCarrinho.Remove(dbItemCarrinho);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
