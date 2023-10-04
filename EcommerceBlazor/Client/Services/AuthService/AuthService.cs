namespace EcommerceBlazor.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<int>> Cadastro(UsuarioCadastro request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/auth/cadastro", request);
            return await resultado.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UsuarioLogin request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            return await resultado.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> TrocarSenha(UsuarioTrocarSenha request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/auth/trocar-senha", request.Senha);
            return await resultado.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
