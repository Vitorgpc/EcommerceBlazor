namespace EcommerceBlazor.Server.Data
{
    public class EcommerceBlazorContext : DbContext
    {
        public EcommerceBlazorContext(DbContextOptions<EcommerceBlazorContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imagem>().HasKey(x => x.Imagem_ID);

            modelBuilder.Entity<Pedido>().HasKey(x => x.Pedido_ID);

            modelBuilder.Entity<ItemPedido>().HasKey(x => new { x.PedidoId, x.ProdutoId, x.TipoProdutoId });

            modelBuilder.Entity<ItemCarrinho>().HasKey(x => new { x.UsuarioId, x.ProdutoId, x.TipoProdutoId });

            modelBuilder.Entity<Usuario>().HasKey(x => x.Usuario_ID);

            modelBuilder.Entity<Endereco>().HasKey(x => x.Endereco_ID);

            modelBuilder.Entity<TipoProduto>().HasKey(x => x.TipoProduto_ID);

            modelBuilder.Entity<TipoProduto>().HasData(
                new TipoProduto { TipoProduto_ID = 1, Nome = "Default" },
                new TipoProduto { TipoProduto_ID = 2, Nome = "Paperback" },
                new TipoProduto { TipoProduto_ID = 3, Nome = "E-Book" },
                new TipoProduto { TipoProduto_ID = 4, Nome = "Audiobook" },
                new TipoProduto { TipoProduto_ID = 5, Nome = "Stream" },
                new TipoProduto { TipoProduto_ID = 6, Nome = "Blu-ray" },
                new TipoProduto { TipoProduto_ID = 7, Nome = "VHS" },
                new TipoProduto { TipoProduto_ID = 8, Nome = "PC" },
                new TipoProduto { TipoProduto_ID = 9, Nome = "PlayStation" },
                new TipoProduto { TipoProduto_ID = 10, Nome = "Xbox" }
           );

            modelBuilder.Entity<ProdutoVariante>().HasKey(x => new { x.ProdutoId, x.TipoProdutoId });

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
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    CategoriaId = 1,
                    Featured = true
                },
                new Produto
                {
                    Produto_ID = 2,
                    Nome = "Ready Player One",
                    Descricao = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                    CategoriaId = 1
                },
                new Produto
                {
                    Produto_ID = 3,
                    Nome = "Nineteen Eighty-Four",
                    Descricao = "Mil Novecentos e Oitenta e Quatro (em inglês: Nineteen Eighty-Four), muitas vezes publicado como 1984, é um romance distópico da autoria do escritor britânico George Orwell e publicado em 1949.[1][2] O romance é ambientado na Pista de Pouso Número 1 (anteriormente conhecida como Grã-Bretanha), uma província do superestado da Oceania, em um mundo de guerra perpétua, vigilância governamental onipresente e manipulação pública e histórica. Os habitantes deste superestado são ditados por um",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/pt/7/74/1984cover.jpg",
                    CategoriaId = 1
                },
                new Produto
                {
                    Produto_ID = 4,
                    Nome = "The Matrix",
                    Descricao = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                    CategoriaId = 2,
                },
                new Produto
                {
                    Produto_ID = 5,
                    CategoriaId = 2,
                    Nome = "Back to the Future",
                    Descricao = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                    Featured = true
                },
                new Produto
                {
                    Produto_ID = 6,
                    CategoriaId = 2,
                    Nome = "Toy Story",
                    Descricao = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                },
                new Produto
                {
                    Produto_ID = 7,
                    CategoriaId = 3,
                    Nome = "Half-Life 2",
                    Descricao = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                },
                new Produto
                {
                    Produto_ID = 8,
                    CategoriaId = 3,
                    Nome = "Diablo II",
                    Descricao = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                },
                new Produto
                {
                    Produto_ID = 9,
                    CategoriaId = 3,
                    Nome = "Day of the Tentacle",
                    Descricao = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                    Featured = true
                },
                new Produto
                {
                    Produto_ID = 10,
                    CategoriaId = 3,
                    Nome = "Xbox",
                    Descricao = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                },
                new Produto
                {
                    Produto_ID = 11,
                    CategoriaId = 3,
                    Nome = "Super Nintendo Entertainment System",
                    Descricao = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                    UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                }
            );

            modelBuilder.Entity<ProdutoVariante>().HasData(
                new ProdutoVariante
                {
                    ProdutoId = 1,
                    TipoProdutoId = 2,
                    Preco = 9.99m,
                    PrecoOriginal = 19.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 1,
                    TipoProdutoId = 3,
                    Preco = 7.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 1,
                    TipoProdutoId = 4,
                    Preco = 19.99m,
                    PrecoOriginal = 29.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 2,
                    TipoProdutoId = 2,
                    Preco = 7.99m,
                    PrecoOriginal = 14.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 3,
                    TipoProdutoId = 2,
                    Preco = 6.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 4,
                    TipoProdutoId = 5,
                    Preco = 3.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 4,
                    TipoProdutoId = 6,
                    Preco = 9.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 4,
                    TipoProdutoId = 7,
                    Preco = 19.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 5,
                    TipoProdutoId = 5,
                    Preco = 3.99m,
                },
                new ProdutoVariante
                {
                    ProdutoId = 6,
                    TipoProdutoId = 5,
                    Preco = 2.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 7,
                    TipoProdutoId = 8,
                    Preco = 19.99m,
                    PrecoOriginal = 29.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 7,
                    TipoProdutoId = 9,
                    Preco = 69.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 7,
                    TipoProdutoId = 10,
                    Preco = 49.99m,
                    PrecoOriginal = 59.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 8,
                    TipoProdutoId = 8,
                    Preco = 9.99m,
                    PrecoOriginal = 24.99m,
                },
                new ProdutoVariante
                {
                    ProdutoId = 9,
                    TipoProdutoId = 8,
                    Preco = 14.99m
                },
                new ProdutoVariante
                {
                    ProdutoId = 10,
                    TipoProdutoId = 1,
                    Preco = 159.99m,
                    PrecoOriginal = 299m
                },
                new ProdutoVariante
                {
                    ProdutoId = 11,
                    TipoProdutoId = 1,
                    Preco = 79.99m,
                    PrecoOriginal = 399m
                }
            );
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<ProdutoVariante> ProdutoVariante { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
    }
}
