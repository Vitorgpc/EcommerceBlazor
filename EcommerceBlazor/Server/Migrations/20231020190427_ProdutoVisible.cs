using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoVisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ProdutoVariante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "ProdutoVariante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 1,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 2,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 3,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 4,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 5,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 6,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 7,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 8,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 9,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 10,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Produto_ID",
                keyValue: 11,
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 4, 5 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 4, 6 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 4, 7 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 6, 5 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 7, 8 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 7, 9 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 7, 10 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 9, 8 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 10, 1 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProdutoVariante",
                keyColumns: new[] { "ProdutoId", "TipoProdutoId" },
                keyValues: new object[] { 11, 1 },
                columns: new[] { "Deleted", "Visible" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ProdutoVariante");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "ProdutoVariante");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Produto");
        }
    }
}
