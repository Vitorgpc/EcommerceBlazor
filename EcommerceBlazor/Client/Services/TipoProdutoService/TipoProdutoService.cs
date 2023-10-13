namespace EcommerceBlazor.Client.Services.TipoProdutoService
{
    public class TipoProdutoService : ITipoProdutoService
    {
        private readonly HttpClient _httpClient;

        public TipoProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<TipoProduto> TipoProdutos { get; set; } = new List<TipoProduto>();

        public event Action OnChange;

        public async Task AtualizarTipoProduto(TipoProduto tipoProduto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/tipoproduto", tipoProduto);
            TipoProdutos = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<TipoProduto>>>()).Data;

            OnChange.Invoke();
        }

        public TipoProduto CriarNovoTipoProduto()
        {
            var novoTipoProduto = new TipoProduto { Editando = true, Novo = true };

            TipoProdutos.Add(novoTipoProduto);

            OnChange.Invoke();

            return novoTipoProduto;
        }

        public async Task CriarTipoProduto(TipoProduto tipoProduto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tipoproduto", tipoProduto);
            TipoProdutos = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<TipoProduto>>>()).Data;

            OnChange.Invoke();
        }

        public async Task GetTipoProdutos()
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<List<TipoProduto>>>("api/tipoproduto");

            TipoProdutos = resultado.Data;
        }
    }
}
