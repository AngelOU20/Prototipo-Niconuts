using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototipo_Niconuts.Data.Migrations
{
    public partial class QuarterMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "t_reclamaciones",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "t_reclamaciones");
        }
    }
}
