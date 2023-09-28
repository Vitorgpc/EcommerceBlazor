namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<Produto>>> GetProdutosAsync();
        Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto);
    }
}
