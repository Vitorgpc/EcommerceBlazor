namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<Produto>>> GetProdutoAsync();
        Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto);
    }
}
