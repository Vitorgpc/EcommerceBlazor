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

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public async Task GetProdutos(string? urlCategoria = null)
        {
            var resultado = urlCategoria == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>("api/produto") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>($"api/produto/categoria/{urlCategoria}");
            
            if (resultado != null && resultado.Data != null)
                Produtos = resultado.Data;

            OnProdutoChanged.Invoke();
        }

        public async Task<ServiceResponse<Produto>> GetProduto(int idProduto)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<Produto>>($"api/produto/{idProduto}");
            return resultado;
        }
    }
}
