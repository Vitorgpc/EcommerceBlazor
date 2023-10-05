using System.Security.Claims;

namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public CarrinhoService(EcommerceBlazorContext context, IHttpContextAccessor httpContext) 
        { 
            _context = context;
            _httpContext = httpContext;
        }

        private int GetUsuarioId() => int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        
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
            itensCarrinho.ForEach(c => c.UsuarioId = GetUsuarioId());
            _context.ItemCarrinho.AddRange(itensCarrinho);

            await _context.SaveChangesAsync();

            var itens = await _context.ItemCarrinho.Where(x => x.UsuarioId == GetUsuarioId()).ToListAsync();

            return await GetProdutosCarrinho(itens);
        }

        public async Task<ServiceResponse<int>> GetQuantidadeItens()
        {
            var count = (await _context.ItemCarrinho.Where(x => x.UsuarioId == GetUsuarioId()).ToListAsync()).Count;
            
            return new ServiceResponse<int> { Data = count };
        }
    }
}
