namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly EcommerceBlazorContext _context;

        public ProdutoService(EcommerceBlazorContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto)
        {
            var response = new ServiceResponse<Produto>();

            var produto = await _context.Produto.FindAsync(idProduto);

            if (produto == null)
            {
                response.Success = false;
                response.Message = "Esse produto não existe!";
            }
            else
            {
                response.Data = produto;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Produto>>> GetProdutosAsync()
        {
            var response = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Produto>>> GetProdutosPorCategoria(string urlCategoria)
        {
            var response = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                     .Where(x => x.Categoria.Url.ToLower().Equals(urlCategoria.ToLower()))
                     .ToListAsync()
            };

            return response;
        }
    }
}
