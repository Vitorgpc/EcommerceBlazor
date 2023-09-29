using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Variante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    TipoProduto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.TipoProduto_ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVariante",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVariante", x => new { x.ProdutoId, x.TipoProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutoVariante_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Produto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoVariante_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProduto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoProduto",
                columns: new[] { "TipoProduto_ID", "Nome" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "Stream" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "ProdutoVariante",
                columns: new[] { "ProdutoId", "TipoProdutoId", "Preco", "PrecoOriginal" },
                values: new object[,]
                {
                    { 1, 2, 9.99m, 19.99m },
                    { 1, 3, 7.99m, 0m },
                    { 1, 4, 19.99m, 29.99m },
                    { 2, 2, 7.99m, 14.99m },
                    { 3, 2, 6.99m, 0m },
                    { 4, 5, 3.99m, 0m },
                    { 4, 6, 9.99m, 0m },
                    { 4, 7, 19.99m, 0m },
                    { 5, 5, 3.99m, 0m },
                    { 6, 5, 2.99m, 0m },
                    { 7, 8, 19.99m, 29.99m },
                    { 7, 9, 69.99m, 0m },
                    { 7, 10, 49.99m, 59.99m },
                    { 8, 8, 9.99m, 24.99m },
                    { 9, 8, 14.99m, 0m },
                    { 10, 1, 159.99m, 299m },
                    { 11, 1, 79.99m, 399m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariante_TipoProdutoId",
                table: "ProdutoVariante",
                column: "TipoProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoVariante");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 1,
                column: "Preco",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 2,
                column: "Preco",
                value: 7.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 3,
                column: "Preco",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 4,
                column: "Preco",
                value: 15.98m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 5,
                column: "Preco",
                value: 16m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 6,
                column: "Preco",
                value: 15.98m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 7,
                column: "Preco",
                value: 215.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 8,
                column: "Preco",
                value: 299.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 9,
                column: "Preco",
                value: 299.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 10,
                column: "Preco",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 11,
                column: "Preco",
                value: 2200.65m);
        }
    }
}
