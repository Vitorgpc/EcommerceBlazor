namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly EcommerceBlazorContext _context;

        public CarrinhoService(EcommerceBlazorContext context) 
        { 
            _context = context;
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
                    TipoProdutoId = variante.TipoProdutoId
                };

                resultado.Data.Add(produtoCarrinho);
            }

            return resultado;
        }
    }
}
