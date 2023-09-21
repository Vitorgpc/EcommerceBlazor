namespace EcommerceBlazor.Server.Data
{
    public class EcommerceBlazorContext : DbContext
    {
        public EcommerceBlazorContext(DbContextOptions<EcommerceBlazorContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }
    }
}
