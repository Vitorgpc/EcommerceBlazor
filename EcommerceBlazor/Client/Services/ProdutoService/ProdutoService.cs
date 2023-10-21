using EcommerceBlazor.Shared;
using System.Collections.Generic;

namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;

        public event Action OnProdutoChanged;

        public ProdutoService(HttpClient http)
        {
            _httpClient = http;
        }

        public List<Produto> AdminProdutos { get; set; } = new List<Produto>();

        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public string Mensagem { get; set; } = "Carregando produtos...";
        public int PaginaAtual { get; set; } = 1;
        public int PaginaCount { get; set; } = 0;
        public string UltimaPesquisa { get; set; } = string.Empty;

        public async Task GetProdutos(string? urlCategoria = null)
        {
            var resultado = urlCategoria == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>("api/produto/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>($"api/produto/categoria/{urlCategoria}");
            
            if (resultado != null && resultado.Data != null)
                Produtos = resultado.Data;

            PaginaAtual = 1;
            PaginaCount = 0;

            if (Produtos.Count == 0)
            {
                Mensagem = "Nenhum Produto Encontrado";
            }

            OnProdutoChanged.Invoke();
        }

        public async Task<ServiceResponse<Produto>> GetProduto(int idProduto)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<Produto>>($"api/produto/{idProduto}");
            return resultado;
        }

        public async Task<List<string>> GetSugestaoProdutos(string pesquisa)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/produto/sugestao-pesquisa/{pesquisa}");

            return resultado.Data;
        }

        public async Task PesquisarProdutos(string pesquisa, int pagina)
        {
            UltimaPesquisa = pesquisa;

            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<PesquisaProdutoResult>>($"api/produto/pesquisa/{pesquisa}/{pagina}");

            if (resultado != null && resultado.Data != null)
            {
                Produtos = resultado.Data.Produtos;
                PaginaAtual = resultado.Data.PaginaAtual;
                PaginaCount = resultado.Data.Paginas;
            }

            if (Produtos.Count == 0)
                Mensagem = "Nenhum produto encontrado!";

            OnProdutoChanged?.Invoke();
        }

        public async Task GetAdminProdutos()
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>("api/produto/admin");
            
            AdminProdutos = resultado.Data;
            PaginaAtual = 1;
            PaginaCount = 0;

            if (AdminProdutos.Count == 0)
                Mensagem = "Nenhum produto cadastrado!";
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/produto", produto);
            return (await resultado.Content.ReadFromJsonAsync<ServiceResponse<Produto>>()).Data;
        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            var resultado = await _httpClient.PutAsJsonAsync("api/produto", produto);
            return (await resultado.Content.ReadFromJsonAsync<ServiceResponse<Produto>>()).Data;
        }

        public async Task DeletarProduto(Produto produto)
        {
            await _httpClient.DeleteAsync($"api/produto/{produto.Produto_ID}");
        }
    }
}
