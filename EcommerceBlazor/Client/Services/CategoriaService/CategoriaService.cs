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
        public List<Categoria> AdminCategorias { get; set; } = new List<Categoria>();

        public event Action OnChange;

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var response = await _httpClient.PutAsJsonAsync("api/categoria/admin", categoria);
            AdminCategorias = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Categoria>>>()).Data;

            await GetCategorias();
            OnChange.Invoke();
        }

        public async Task CriarCategoria(Categoria categoria)
        {
            var response = await _httpClient.PostAsJsonAsync("api/categoria/admin", categoria);
            AdminCategorias = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Categoria>>>()).Data;

            await GetCategorias();
            OnChange.Invoke();
        }

        public Categoria CriarNovaCategoria()
        {
            var novaCategoria = new Categoria
            {
                Novo = true, Editando = true
            };

            AdminCategorias.Add(novaCategoria);
            OnChange.Invoke();

            return novaCategoria;
        }

        public async Task DeletarCategoria(int categoriaId)
        {
            var response = await _httpClient.DeleteAsync($"api/categoria/admin/{categoriaId}");
            AdminCategorias = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Categoria>>>()).Data;

            await GetCategorias();
            OnChange.Invoke();
        }

        public async Task GetAdminCategorias()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Categoria>>>("api/categoria/admin");

            if (response != null && response.Data != null)
            {
                AdminCategorias = response.Data;
            }
        }

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
