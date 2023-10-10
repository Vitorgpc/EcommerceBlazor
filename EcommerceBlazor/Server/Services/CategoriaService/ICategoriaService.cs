namespace EcommerceBlazor.Server.Services.CategoriaService
{
    public interface ICategoriaService
    {
        Task<ServiceResponse<List<Categoria>>> GetCategorias();
        Task<ServiceResponse<List<Categoria>>> GetAdminCategorias();
        Task<ServiceResponse<List<Categoria>>> CriarCategoria(Categoria categoria);
        Task<ServiceResponse<List<Categoria>>> AtualizarCategoria(Categoria categoria);
        Task<ServiceResponse<List<Categoria>>> DeletarCategoria(int id);
    }
}
