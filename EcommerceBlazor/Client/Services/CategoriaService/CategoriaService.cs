namespace EcommerceBlazor.Client.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient http)
        {
            _httpClient = http;
        }

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        public async Task GetCategorias()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Categoria>>>("api/categoria");

            if (response != null && response.Data != null)
            {
                Categorias = response.Data;
            }
        }
    }
}
