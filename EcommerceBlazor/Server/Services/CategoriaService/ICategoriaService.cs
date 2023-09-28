namespace EcommerceBlazor.Server.Services.CategoriaService
{
    public interface ICategoriaService
    {
        Task<ServiceResponse<List<Categoria>>> GetCategoriasAsync();
    }
}
