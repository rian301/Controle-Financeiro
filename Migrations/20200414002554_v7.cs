using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Usuario_UserId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_UserId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_UserId",
                table: "Categoria",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Usuario_UserId",
                table: "Categoria",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
