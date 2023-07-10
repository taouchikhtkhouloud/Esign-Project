using Microsoft.EntityFrameworkCore.Migrations;

namespace Esign.Infrastructure.Migrations
{
    public partial class UpdateDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fileType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "keywords",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "fileType",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "keywords",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Documents");
        }
    }
}
