namespace EcommerceBlazor.Client.Services.PedidoService
{
    public interface IPedidoService
    {
        Task<string> CriarPedido();
        Task<List<PedidoOverviewResponse>> GetPedidos();
        Task<PedidoDetalhesResponse> GetDetalhesPedido(int pedidoId);
    }
}
