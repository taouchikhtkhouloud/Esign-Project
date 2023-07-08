using Microsoft.EntityFrameworkCore.Migrations;

namespace Esign.Infrastructure.Migrations
{
    public partial class MyDemoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "DocumentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parent",
                table: "DocumentTypes");
        }
    }
}
