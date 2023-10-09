using Stripe.Checkout;

namespace EcommerceBlazor.Server.Services.PagamentoService
{
    public interface IPagamentoService
    {
        Task<Session> CriarSessaoCheckout();
        Task<ServiceResponse<bool>> FulfillPedido(HttpRequest request);
    }
}
