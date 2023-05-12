using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class AddLoginColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TB_USER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "TB_USER",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TB_USER");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TB_USER");
        }
    }
}
