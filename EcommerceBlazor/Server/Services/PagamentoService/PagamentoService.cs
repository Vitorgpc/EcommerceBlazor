using Stripe;
using Stripe.Checkout;

namespace EcommerceBlazor.Server.Services.PagamentoService
{
    public class PagamentoService : IPagamentoService
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly IAuthService _authService;
        private readonly IPedidoService _pedidoService;

        const string secret = "whsec_4bcd2d93cd2a25e3d5091ce9e839427231af77805795aa1e9b5e1ddb6f5e7fc8";

        public PagamentoService(ICarrinhoService carrinhoService, IAuthService authService, IPedidoService pedidoService)
        {
            StripeConfiguration.ApiKey = "sk_test_51HJWDBLWY0cFbLKWm8fKjx16bLQDK4gWEJ4emF73QwZDSIx0DJSU32rFhjUpIF5JNW8JA4rn9ACFzphd987BK9r500q6IPWKnz";

            _carrinhoService = carrinhoService;
            _authService = authService;
            _pedidoService = pedidoService;
        }

        public async Task<Session> CriarSessaoCheckout()
        {
            var produtos = (await _carrinhoService.GetProdutosCarrinhoDB()).Data;

            var lineItems = new List<SessionLineItemOptions>();

            produtos.ForEach(produto => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = produto.Preco * 100,
                    Currency = "brl",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = produto.Nome,
                        Images = new List<string> { produto.UrlImagem }
                    }
                },
                Quantity = produto.Quantidade
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUsuarioEmail(),
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "US", "BR" }
                },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7060/pedido-success",
                CancelUrl = "https://localhost:7060/carrinho",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillPedido(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, request.Headers["Stripe-Signature"], secret, 300, false);

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var usuario = await _authService.GetUsuarioPorEmail(session.CustomerEmail);
                    await _pedidoService.CriarPedido(usuario.Usuario_ID);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch(StripeException ex)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = ex.Message };
            }
        }
    }
}
