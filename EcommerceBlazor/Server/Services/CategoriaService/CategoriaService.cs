namespace EcommerceBlazor.Server.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly EcommerceBlazorContext _context;

        public CategoriaService(EcommerceBlazorContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Categoria>>> AtualizarCategoria(Categoria categoria)
        {
            Categoria dbCategoria = await GetCategoria(categoria.Categoria_ID);

            if (dbCategoria == null)
            {
                return new ServiceResponse<List<Categoria>>
                {
                    Success = false,
                    Message = "Categoria não encontrada"
                };
            }

            dbCategoria.Nome = categoria.Nome;
            dbCategoria.Url = categoria.Url;
            dbCategoria.Visible = categoria.Visible;

            await _context.SaveChangesAsync();

            return await GetAdminCategorias();
        }

        public async Task<ServiceResponse<List<Categoria>>> CriarCategoria(Categoria categoria)
        {
            categoria.Editando = categoria.Novo = false;

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return await GetAdminCategorias();
        }

        public async Task<ServiceResponse<List<Categoria>>> DeletarCategoria(int id)
        {
            Categoria categoria = await GetCategoria(id);

            if (categoria == null)
            {
                return new ServiceResponse<List<Categoria>>
                {
                    Success = false,
                    Message = "Categoria não encontrada"
                };
            }

            categoria.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetAdminCategorias();
        }

        public async Task<ServiceResponse<List<Categoria>>> GetAdminCategorias()
        {
            var categorias = await _context.Categoria.Where(x => !x.Deleted).ToListAsync();

            return new ServiceResponse<List<Categoria>>
            {
                Data = categorias
            };
        }

        public async Task<ServiceResponse<List<Categoria>>> GetCategorias()
        {
            var categorias = await _context.Categoria.Where(x => !x.Deleted && x.Visible).ToListAsync();

            return new ServiceResponse<List<Categoria>>
            {
                Data = categorias
            };
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _context.Categoria.FirstOrDefaultAsync(c => c.Categoria_ID == id);
        }
    }
}
