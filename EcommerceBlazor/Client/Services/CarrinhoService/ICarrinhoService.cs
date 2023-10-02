namespace EcommerceBlazor.Client.Services.CarrinhoService
{
    public interface ICarrinhoService
    {
        event Action OnChange;
        Task AddToCart(ItemCarrinho itemCarrinho);
        Task<List<ItemCarrinho>> GetItemCarrinhos();
        Task<List<CarrinhoProdutoResponse>> GetProdutosCarrinho();
        Task RemoverItemCarrinho(int produtoId, int tipoProdutoId);
        Task AtualizarQuantidade(CarrinhoProdutoResponse produto);
    }
}
