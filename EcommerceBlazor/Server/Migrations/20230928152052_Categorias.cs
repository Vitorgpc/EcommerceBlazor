using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Categoria_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Categoria_ID);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_ID", "Nome", "Url" },
                values: new object[,]
                {
                    { 1, "Livros", "livros" },
                    { 2, "Filmes", "filmes" },
                    { 3, "Video Games", "video-games" }
                });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 1,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 2,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 3,
                column: "CategoriaId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Categoria_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produto");
        }
    }
}
