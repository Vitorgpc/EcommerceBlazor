using System.Security.Claims;

namespace EcommerceBlazor.Server.Services.PedidoService
{
    public class PedidoService : IPedidoService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly ICarrinhoService _carrinhoService;
        private readonly IHttpContextAccessor _httpContext;

        public PedidoService(EcommerceBlazorContext context, ICarrinhoService carrinhoService, IHttpContextAccessor httpContext)
        {
            _context = context;
            _carrinhoService = carrinhoService;
            _httpContext = httpContext;
        }

        private int GetUsuarioId() => int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

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
                UsuarioId = GetUsuarioId(),
                DataPedido = DateTime.Now,
                PrecoTotal = precoTotal,
                Itens = itensPedido
            };

            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
