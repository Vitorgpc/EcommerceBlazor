namespace EcommerceBlazor.Server.Services.TipoProdutoService
{
    public interface ITipoProdutoService
    {
        Task<ServiceResponse<List<TipoProduto>>> GetTipoProduto();
        Task<ServiceResponse<List<TipoProduto>>> AdicionarTipoProduto(TipoProduto tipoProduto);
        Task<ServiceResponse<List<TipoProduto>>> AtualizarTipoProduto(TipoProduto tipoProduto);
    }
}
