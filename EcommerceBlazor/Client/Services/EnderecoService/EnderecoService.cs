namespace EcommerceBlazor.Client.Services.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> AdicionarOuAtualizarEndereco(Endereco endereco)
        {
            var response = await _httpClient.PostAsJsonAsync("api/endereco", endereco);
            return response.Content.ReadFromJsonAsync<ServiceResponse<Endereco>>().Result.Data;
        }

        public async Task<Endereco> GetEndereco()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Endereco>>("api/endereco");
            return response.Data;
        }
    }
}
