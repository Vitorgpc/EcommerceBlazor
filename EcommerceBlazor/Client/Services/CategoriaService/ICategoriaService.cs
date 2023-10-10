namespace EcommerceBlazor.Client.Services.CategoriaService
{
    public interface ICategoriaService
    {
        event Action OnChange;
        List<Categoria> Categorias { get; set; }
        List<Categoria> AdminCategorias { get; set; }
        Task GetCategorias();
        Task GetAdminCategorias();
        Task CriarCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
        Task DeletarCategoria(int categoriaId);
        Categoria CriarNovaCategoria();
    }
}
