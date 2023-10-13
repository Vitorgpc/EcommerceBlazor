namespace EcommerceBlazor.Server.Services.TipoProdutoService
{
    public class TipoProdutoService : ITipoProdutoService
    {
        private readonly EcommerceBlazorContext _context;

        public TipoProdutoService(EcommerceBlazorContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TipoProduto>>> AdicionarTipoProduto(TipoProduto tipoProduto)
        {
            tipoProduto.Editando = tipoProduto.Novo = false;

            _context.TipoProduto.Add(tipoProduto);
            await _context.SaveChangesAsync();

            return await GetTipoProduto();
        }

        public async Task<ServiceResponse<List<TipoProduto>>> AtualizarTipoProduto(TipoProduto tipoProduto)
        {
            var dbTipoProduto = await _context.TipoProduto.FindAsync(tipoProduto.TipoProduto_ID);

            if (dbTipoProduto == null)
            {
                return new ServiceResponse<List<TipoProduto>>
                {
                    Success = false,
                    Message = "Tipo de Produto não encontrado!"
                };
            }

            dbTipoProduto.Nome = tipoProduto.Nome;

            await _context.SaveChangesAsync();

            return await GetTipoProduto();
        }

        public async Task<ServiceResponse<List<TipoProduto>>> GetTipoProduto()
        {
            var tiposProduto = await _context.TipoProduto.ToListAsync();
            return new ServiceResponse<List<TipoProduto>> { Data = tiposProduto };
        }
    }
}
