﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Produto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Produto_ID);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Produto_ID", "Descricao", "Nome", "Preco", "UrlImagem" },
                values: new object[,]
                {
                    { 1, "The Hitchhiker's Guide to the Galaxy[a][b] is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.", "The Hitchhiker's Guide to the Galaxy", 9.99m, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg" },
                    { 2, "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]", "Ready Player One", 7.99m, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg" },
                    { 3, "Mil Novecentos e Oitenta e Quatro (em inglês: Nineteen Eighty-Four), muitas vezes publicado como 1984, é um romance distópico da autoria do escritor britânico George Orwell e publicado em 1949.[1][2] O romance é ambientado na Pista de Pouso Número 1 (anteriormente conhecida como Grã-Bretanha), uma província do superestado da Oceania, em um mundo de guerra perpétua, vigilância governamental onipresente e manipulação pública e histórica. Os habitantes deste superestado são ditados por um", "Nineteen Eighty-Four", 8.99m, "https://upload.wikimedia.org/wikipedia/pt/7/74/1984cover.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
