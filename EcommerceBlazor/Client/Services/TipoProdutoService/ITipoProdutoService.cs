namespace EcommerceBlazor.Client.Services.TipoProdutoService
{
    public interface ITipoProdutoService
    {
        event Action OnChange;
        List<TipoProduto> TipoProdutos { get; set; }
        Task GetTipoProdutos();
        Task CriarTipoProduto(TipoProduto tipoProduto);
        Task AtualizarTipoProduto(TipoProduto tipoProduto);
        TipoProduto CriarNovoTipoProduto();
    }
}
