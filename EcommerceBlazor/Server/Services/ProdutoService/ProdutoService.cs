namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public ProdutoService(EcommerceBlazorContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ServiceResponse<Produto>> AtualizarProduto(Produto produto)
        {
            var dbProduto = await _context.Produto.FindAsync(produto.Produto_ID);

            if (dbProduto == null)
            {
                return new ServiceResponse<Produto>
                {
                    Success = false,
                    Message = "Produto não existe!"
                };
            }

            dbProduto.Nome = produto.Nome;
            dbProduto.Descricao = produto.Descricao;
            dbProduto.UrlImagem = produto.UrlImagem;
            dbProduto.CategoriaId = produto.CategoriaId;
            dbProduto.Visible = produto.Visible;
            dbProduto.Featured = produto.Featured;

            foreach (var variante in produto.Variantes)
            {
                var dbVariante = await _context.ProdutoVariante.SingleOrDefaultAsync(v => 
                    v.ProdutoId == variante.ProdutoId &&
                    v.TipoProdutoId == variante.TipoProdutoId);

                if (dbVariante == null)
                {
                    variante.TipoProduto = null;
                    _context.ProdutoVariante.Add(variante);
                }
                else
                {
                    dbVariante.TipoProduto = variante.TipoProduto;
                    dbVariante.Preco = variante.Preco;
                    dbVariante.PrecoOriginal = variante.PrecoOriginal;
                    dbVariante.Visible = variante.Visible;
                    dbVariante.Deleted = variante.Deleted;
                }
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<Produto> { Data = produto };
        }

        public async Task<ServiceResponse<Produto>> CriarProduto(Produto produto)
        {
            foreach (var variante in produto.Variantes)
            {
                variante.TipoProduto = null;
            }

            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Produto> { Data = produto };
        }

        public async Task<ServiceResponse<bool>> DeletarProduto(int produtoId)
        {
            var dbProduto = await _context.Produto.FindAsync(produtoId);

            if (dbProduto == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Produto não existe!"
                };
            }

            dbProduto.Deleted = true;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Produto>>> GetAdminProdutos()
        {
            var resposta = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                    .Where(p => !p.Deleted)
                    .Include(x => x.Variantes.Where(v => !v.Deleted))
                    .ThenInclude(v => v.TipoProduto)
                    .ToListAsync()
            };

            return resposta;
        }

        public async Task<ServiceResponse<List<Produto>>> GetFeaturedProdutos()
        {
            var resposta = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                    .Where(p => p.Featured && p.Visible && !p.Deleted)
                    .Include(x => x.Variantes.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return resposta;
        }

        public async Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto)
        {
            var response = new ServiceResponse<Produto>();

            Produto produto = null;

            if (_httpContext.HttpContext.User.IsInRole("Admin"))
            {
                produto = await _context.Produto
                    .Include(x => x.Variantes.Where(v => !v.Deleted))
                    .ThenInclude(t => t.TipoProduto)
                    .FirstOrDefaultAsync(p => p.Produto_ID == idProduto && !p.Deleted);
            }
            else
            {
                produto = await _context.Produto
                    .Include(x => x.Variantes.Where(v => v.Visible && !v.Deleted))
                    .ThenInclude(t => t.TipoProduto)
                    .FirstOrDefaultAsync(p => p.Produto_ID == idProduto && !p.Deleted && p.Visible);
            }

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
                Data = await _context.Produto
                    .Where(p => p.Visible && !p.Deleted)
                    .Include(x => x.Variantes.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Produto>>> GetProdutosPorCategoria(string urlCategoria)
        {
            var response = new ServiceResponse<List<Produto>>
            {
                Data = await _context.Produto
                     .Where(p => p.Categoria.Url.ToLower().Equals(urlCategoria.ToLower()) &&
                        p.Visible && !p.Deleted)
                     .Include(x => x.Variantes.Where(v => v.Visible && !v.Deleted))
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

        public async Task<ServiceResponse<PesquisaProdutoResult>> PesquisaProdutos(string pesquisa, int pagina)
        {
            var pageResult = 2f;
            var pageCount = Math.Ceiling((await GetProdutosPorPesquisa(pesquisa)).Count / pageResult);

            var produtos = await _context.Produto.Where(x =>
                                x.Nome.ToLower().Contains(pesquisa.ToLower()) ||
                                x.Descricao.ToLower().Contains(pesquisa.ToLower()) && 
                                x.Visible && !x.Deleted)
                                .Include(v => v.Variantes)
                                .Skip((pagina - 1) * (int)pageResult)
                                .Take((int)pageResult)
                                .ToListAsync();

            var resposta = new ServiceResponse<PesquisaProdutoResult>
            {
                Data = new PesquisaProdutoResult {
                    Produtos = produtos,
                    PaginaAtual = pagina,
                    Paginas = (int)pageCount
                }
            };

            return resposta;
        }

        private async Task<List<Produto>> GetProdutosPorPesquisa(string pesquisa)
        {
            return await _context.Produto.Where(x =>
                                x.Nome.ToLower().Contains(pesquisa.ToLower()) ||
                                x.Descricao.ToLower().Contains(pesquisa.ToLower()) &&
                                x.Visible && !x.Deleted)
                                .Include(v => v.Variantes)
                                .ToListAsync();
        }
    }
}
