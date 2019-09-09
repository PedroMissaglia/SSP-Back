using Microsoft.EntityFrameworkCore.Migrations;

namespace superSecretProject.Migrations
{
    public partial class adicaoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Users");
        }
    }
}
