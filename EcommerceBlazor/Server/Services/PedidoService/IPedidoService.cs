namespace EcommerceBlazor.Server.Services.PedidoService
{
    public interface IPedidoService
    {
        Task<ServiceResponse<bool>> CriarPedido();
        Task<ServiceResponse<List<PedidoOverviewResponse>>> GetPedidos();
    }
}
