using Microsoft.EntityFrameworkCore.Migrations;

namespace ornekWeb.Migrations
{
    public partial class QAekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questionanswers",
                columns: table => new
                {
                    questionAnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firmId = table.Column<int>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionanswers", x => x.questionAnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questionanswers");
        }
    }
}
