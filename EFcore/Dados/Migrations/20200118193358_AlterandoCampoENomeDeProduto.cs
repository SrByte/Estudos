using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class AlterandoCampoENomeDeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaID",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaID",
                table: "Produto",
                newName: "IX_Produto_CategoriaID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produto",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categorias_CategoriaID",
                table: "Produto",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categorias_CategoriaID",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_CategoriaID",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaID",
                table: "Produtos",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
