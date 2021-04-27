using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolioAPI.Migrations
{
    public partial class AboutMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolishDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMe", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "EnglishDescription", "Photo", "PolishDescription" },
                values: new object[] { 1, "Template", null, "Wzor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutMe");
        }
    }
}
