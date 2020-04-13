using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalarioLiquido",
                table: "Usuario");

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Usuario",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Usuario");

            migrationBuilder.AddColumn<float>(
                name: "SalarioLiquido",
                table: "Usuario",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
