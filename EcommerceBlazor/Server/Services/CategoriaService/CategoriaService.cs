namespace EcommerceBlazor.Server.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly EcommerceBlazorContext _context;

        public CategoriaService(EcommerceBlazorContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Categoria>>> GetCategoriasAsync()
        {
            var categorias = await _context.Categoria.ToListAsync();

            return new ServiceResponse<List<Categoria>>
            {
                Data = categorias
            };
        }
    }
}
