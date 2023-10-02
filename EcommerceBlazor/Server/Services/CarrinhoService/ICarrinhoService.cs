namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public interface ICarrinhoService
    {
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinho(List<ItemCarrinho> itensCarrinho);
    }
}
