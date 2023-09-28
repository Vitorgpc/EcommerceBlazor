namespace EcommerceBlazor.Client.Services.CategoriaService
{
    public interface ICategoriaService
    {
        List<Categoria> Categorias { get; set; }
        Task GetCategorias();
    }
}
