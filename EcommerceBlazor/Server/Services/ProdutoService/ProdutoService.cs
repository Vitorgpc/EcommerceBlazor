namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly EcommerceBlazorContext _context;

        public ProdutoService(EcommerceBlazorContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Produto>>> GetFeaturedProdutos()
        {
            var resposta = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                    .Where(x => x.Featured)
                    .Include(v => v.Variantes)
                    .ToListAsync()
            };

            return resposta;
        }

        public async Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto)
        {
            var response = new ServiceResponse<Produto>();

            var produto = await _context.Produto
                .Include(v => v.Variantes)
                .ThenInclude(t => t.TipoProduto)
                .FirstOrDefaultAsync(p => p.Produto_ID == idProduto);

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
                Data = await _context.Produto.Include(v => v.Variantes).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Produto>>> GetProdutosPorCategoria(string urlCategoria)
        {
            var response = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                     .Where(x => x.Categoria.Url.ToLower().Equals(urlCategoria.ToLower()))
                     .Include(v => v.Variantes)
                     .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetSugestaoPesquisa(string pesquisa)
        {
            var produtos = await GetProdutosPorPesquisa(pesquisa);

            List<string> resultado = new List<string>();

            foreach(var produto in produtos)
            {
                if (produto.Nome.Contains(pesquisa, StringComparison.OrdinalIgnoreCase))
                {
                    resultado.Add(produto.Nome);
                }

                if (produto.Descricao != null)
                {
                    var pontuacao = produto.Descricao.Where(char.IsPunctuation)
                        .Distinct().ToArray();

                    var palavras = produto.Descricao.Split()
                        .Select(s => s.Trim(pontuacao));

                    foreach(var palavra in palavras)
                    {
                        if (palavra.Contains(pesquisa, StringComparison.OrdinalIgnoreCase)
                            && !resultado.Contains(palavra))
                        {
                            resultado.Add(palavra);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = resultado };
        }

        public async Task<ServiceResponse<List<Produto>>> PesquisaProdutos(string pesquisa)
        {
            var resposta = new ServiceResponse<List<Produto>>
            {
                Data = await GetProdutosPorPesquisa(pesquisa)
            };

            return resposta;
        }

        private async Task<List<Produto>> GetProdutosPorPesquisa(string pesquisa)
        {
            return await _context.Produto.Where(x =>
                                x.Nome.ToLower().Contains(pesquisa.ToLower()) ||
                                x.Descricao.ToLower().Contains(pesquisa.ToLower()))
                                .Include(v => v.Variantes)
                                .ToListAsync();
        }
    }
}
