namespace EcommerceBlazor.Client.Services.ProdutoService
{
    public interface IProdutoService
    {
        event Action OnProdutoChanged;
        List<Produto> Produtos { get; set; }
        string Mensagem { get; set; }
        int PaginaAtual { get; set; }
        int PaginaCount { get; set; }
        string UltimaPesquisa { get; set; }
        Task GetProdutos(string? urlCategoria = null);
        Task<ServiceResponse<Produto>> GetProduto(int idProduto);
        Task PesquisarProdutos(string pesquisa, int pagina);
        Task<List<string>> GetSugestaoProdutos(string pesquisa);
    }
}
