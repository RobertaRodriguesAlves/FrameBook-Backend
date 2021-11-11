using Microsoft.EntityFrameworkCore.Migrations;

namespace Framebook.Infra.Data.Migrations
{
    public partial class AddStacksExperiencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StackExperiencia",
                columns: table => new
                {
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    StackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StackExperiencia", x => new { x.ProfissionalId, x.StackId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StackExperiencia");
        }
    }
}
