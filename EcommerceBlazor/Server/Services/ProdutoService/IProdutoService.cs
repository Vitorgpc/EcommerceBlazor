namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<Produto>>> GetProdutosAsync();
        Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto);
        Task<ServiceResponse<List<Produto>>> GetProdutosPorCategoria(string urlCategoria);
        Task<ServiceResponse<List<Produto>>> PesquisaProdutos(string pesquisa);
        Task<ServiceResponse<List<string>>> GetSugestaoPesquisa(string pesquisa);
        Task<ServiceResponse<List<Produto>>> GetFeaturedProdutos();
    }
}
