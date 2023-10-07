namespace EcommerceBlazor.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider stateProvider)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
        }

        public async Task<ServiceResponse<int>> Cadastro(UsuarioCadastro request)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/auth/cadastro", request);
            return await resultado.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _stateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
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
