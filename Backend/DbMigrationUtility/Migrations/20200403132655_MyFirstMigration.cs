using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrationUtility.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suggest",
                columns: table => new
                {
                    suggestion = table.Column<string>(nullable: false),
                    nn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suggest", x => x.suggestion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "suggest");
        }
    }
}
