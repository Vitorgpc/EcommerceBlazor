namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public interface ICarrinhoService
    {
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinho(List<ItemCarrinho> itensCarrinho);
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GravarItensCarrinho(List<ItemCarrinho> itensCarrinho);
        Task<ServiceResponse<int>> GetQuantidadeItens();
    }
}
