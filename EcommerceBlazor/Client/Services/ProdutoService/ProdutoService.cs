namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService(HttpClient http)
        {
            _httpClient = http;
        }

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public async Task GetProdutos()
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Produto>>>("api/produto");
            if (resultado != null && resultado.Data != null)
                Produtos = resultado.Data;
        }

        public async Task<ServiceResponse<Produto>> GetProduto(int idProduto)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<Produto>>($"api/produto/{idProduto}");
            return resultado;
        }
    }
}
