namespace EcommerceBlazor.Server.Data
{
    public class EcommerceBlazorContext : DbContext
    {
        public EcommerceBlazorContext(DbContextOptions<EcommerceBlazorContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(x => x.Categoria_ID);
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Categoria_ID = 1,
                    Nome = "Livros",
                    Url = "livros"
                },
                new Categoria
                {
                    Categoria_ID = 2,
                    Nome = "Filmes",
                    Url = "filmes"
                },
                new Categoria
                {
                    Categoria_ID = 3,
                    Nome = "Video Games",
                    Url = "video-games"
                }
            );

            modelBuilder.Entity<Produto>().HasKey(x => x.Produto_ID);
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Produto_ID = 1,
                    Nome = "The Hitchhiker's Guide to the Galaxy",
                    Descricao = "The Hitchhiker's Guide to the Galaxy[a][b] is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.",
                    Preco = 9.99m,
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    CategoriaId = 1
                },
                new Produto
                {
                    Produto_ID = 2,
                    Nome = "Ready Player One",
                    Descricao = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                    Preco = 7.99m,
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                    CategoriaId = 1
                },
                new Produto
                {
                    Produto_ID = 3,
                    Nome = "Nineteen Eighty-Four",
                    Descricao = "Mil Novecentos e Oitenta e Quatro (em inglês: Nineteen Eighty-Four), muitas vezes publicado como 1984, é um romance distópico da autoria do escritor britânico George Orwell e publicado em 1949.[1][2] O romance é ambientado na Pista de Pouso Número 1 (anteriormente conhecida como Grã-Bretanha), uma província do superestado da Oceania, em um mundo de guerra perpétua, vigilância governamental onipresente e manipulação pública e histórica. Os habitantes deste superestado são ditados por um",
                    Preco = 8.99m,
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/pt/7/74/1984cover.jpg",
                    CategoriaId = 1
                }
            );
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
