using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolioAPI.Migrations
{
    public partial class skillsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Skills",
                newName: "PolishDescription");

            migrationBuilder.AddColumn<string>(
                name: "EnglishDescription",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishDescription",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PolishDescription",
                table: "Skills",
                newName: "Description");
        }
    }
}
