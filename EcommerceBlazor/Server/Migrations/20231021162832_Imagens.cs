using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Imagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Imagem_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Produto_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Imagem_ID);
                    table.ForeignKey(
                        name: "FK_Imagem_Produto_Produto_ID",
                        column: x => x.Produto_ID,
                        principalTable: "Produto",
                        principalColumn: "Produto_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_Produto_ID",
                table: "Imagem",
                column: "Produto_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagem");
        }
    }
}
