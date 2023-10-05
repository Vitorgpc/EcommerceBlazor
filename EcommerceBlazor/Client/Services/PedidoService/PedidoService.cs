using Microsoft.AspNetCore.Components;

namespace EcommerceBlazor.Client.Services.PedidoService
{
    public class PedidoService : IPedidoService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;
        private readonly NavigationManager _navigationManager;

        public PedidoService(HttpClient httpClient, AuthenticationStateProvider stateProvider, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
            _navigationManager = navigationManager;
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _stateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task CriarPedido()
        {
            if (await IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/pedido", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }
    }
}
