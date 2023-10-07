using Microsoft.AspNetCore.Components;

namespace EcommerceBlazor.Client.Services.PedidoService
{
    public class PedidoService : IPedidoService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        private readonly NavigationManager _navigationManager;

        public PedidoService(HttpClient httpClient, IAuthService authService, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _authService = authService;
            _navigationManager = navigationManager;
        }

        public async Task CriarPedido()
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/pedido", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }

        public async Task<List<PedidoOverviewResponse>> GetPedidos()
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<List<PedidoOverviewResponse>>>("api/pedido");

            return resultado.Data;
        }

        public async Task<PedidoDetalhesResponse> GetDetalhesPedido(int pedidoId)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<PedidoDetalhesResponse>>($"api/pedido/{pedidoId}");
            return resultado.Data;
        }
    }
}
