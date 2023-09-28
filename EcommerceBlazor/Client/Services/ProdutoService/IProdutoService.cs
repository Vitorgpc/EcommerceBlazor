namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public interface IProdutoService
    {
        event Action OnProdutoChanged;
        List<Produto> Produtos { get; set; }
        Task GetProdutos(string? urlCategoria = null);
        Task<ServiceResponse<Produto>> GetProduto(int idProduto);
    }
}
