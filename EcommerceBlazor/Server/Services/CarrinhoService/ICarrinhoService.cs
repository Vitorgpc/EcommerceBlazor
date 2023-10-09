namespace EcommerceBlazor.Server.Services.CarrinhoService
{
    public interface ICarrinhoService
    {
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinho(List<ItemCarrinho> itensCarrinho);
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GravarItensCarrinho(List<ItemCarrinho> itensCarrinho);
        Task<ServiceResponse<int>> GetQuantidadeItens();
        Task<ServiceResponse<List<CarrinhoProdutoResponse>>> GetProdutosCarrinhoDB(int? usuarioId = null);
        Task<ServiceResponse<bool>> AdicionarItemCarrinho(ItemCarrinho itemCarrinho);
        Task<ServiceResponse<bool>> AtualizarQuantidade(ItemCarrinho itemCarrinho);
        Task<ServiceResponse<bool>> RemoverItemCarrinho(int produtoId, int tipoProdutoId);
    }
}
