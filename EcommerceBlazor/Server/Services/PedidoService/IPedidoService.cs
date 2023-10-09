namespace EcommerceBlazor.Server.Services.PedidoService
{
    public interface IPedidoService
    {
        Task<ServiceResponse<bool>> CriarPedido(int usuarioId);
        Task<ServiceResponse<List<PedidoOverviewResponse>>> GetPedidos();
        Task<ServiceResponse<PedidoDetalhesResponse>> GetDetalhesPedido(int pedidoId);
    }
}
