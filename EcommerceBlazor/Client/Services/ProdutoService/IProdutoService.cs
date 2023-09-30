namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public interface IProdutoService
    {
        event Action OnProdutoChanged;
        List<Produto> Produtos { get; set; }
        string Mensagem { get; set; }
        Task GetProdutos(string? urlCategoria = null);
        Task<ServiceResponse<Produto>> GetProduto(int idProduto);
        Task PesquisarProdutos(string pesquisa);
        Task<List<string>> GetSugestaoProdutos(string pesquisa);
    }
}
