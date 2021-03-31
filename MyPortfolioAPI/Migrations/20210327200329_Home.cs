using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolioAPI.Migrations
{
    public partial class Home : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Homes",
                columns: new[] { "Id", "Image", "Label", "Language", "Photo", "Text", "UnderText" },
                values: new object[] { 1, null, "Hello", "english", null, "I am Grzegorz Aszlar", "Fullstack Developer" });

            migrationBuilder.InsertData(
                table: "Homes",
                columns: new[] { "Id", "Image", "Label", "Language", "Photo", "Text", "UnderText" },
                values: new object[] { 2, null, "Cześć", "polish", null, "Nazywam się Grzegorz Aszlar", "Fullstack Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
