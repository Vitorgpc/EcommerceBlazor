namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public interface IProdutoService
    {
        List<Produto> Produtos { get; set; }
        Task GetProdutos();
        Task<ServiceResponse<Produto>> GetProduto(int idProduto);
    }
}
