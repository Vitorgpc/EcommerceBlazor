﻿// <auto-generated />
using EcommerceBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    [DbContext(typeof(EcommerceBlazorContext))]
    [Migration("20230922010015_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceBlazor.Shared.Produto", b =>
                {
                    b.Property<int>("Produto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Produto_ID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlImagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Produto_ID");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Produto_ID = 1,
                            Descricao = "The Hitchhiker's Guide to the Galaxy[a][b] is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.",
                            Nome = "The Hitchhiker's Guide to the Galaxy",
                            Preco = 9.99m,
                            UrlImagem = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg"
                        },
                        new
                        {
                            Produto_ID = 2,
                            Descricao = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                            Nome = "Ready Player One",
                            Preco = 7.99m,
                            UrlImagem = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg"
                        },
                        new
                        {
                            Produto_ID = 3,
                            Descricao = "Mil Novecentos e Oitenta e Quatro (em inglês: Nineteen Eighty-Four), muitas vezes publicado como 1984, é um romance distópico da autoria do escritor britânico George Orwell e publicado em 1949.[1][2] O romance é ambientado na Pista de Pouso Número 1 (anteriormente conhecida como Grã-Bretanha), uma província do superestado da Oceania, em um mundo de guerra perpétua, vigilância governamental onipresente e manipulação pública e histórica. Os habitantes deste superestado são ditados por um",
                            Nome = "Nineteen Eighty-Four",
                            Preco = 8.99m,
                            UrlImagem = "https://upload.wikimedia.org/wikipedia/pt/7/74/1984cover.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
