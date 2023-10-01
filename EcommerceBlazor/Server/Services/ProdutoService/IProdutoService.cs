namespace EcommerceBlazor.Server.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<Produto>>> GetProdutosAsync();
        Task<ServiceResponse<Produto>> GetProdutoAsync(int idProduto);
        Task<ServiceResponse<List<Produto>>> GetProdutosPorCategoria(string urlCategoria);
        Task<ServiceResponse<PesquisaProdutoResult>> PesquisaProdutos(string pesquisa, int pagina);
        Task<ServiceResponse<List<string>>> GetSugestaoPesquisa(string pesquisa);
        Task<ServiceResponse<List<Produto>>> GetFeaturedProdutos();
    }
}
