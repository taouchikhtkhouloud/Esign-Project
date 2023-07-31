using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Esign.Infrastructure.Migrations
{
    public partial class SignDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeSignature",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSignature",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileUrlsSigne",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomSignateur",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrenomSignateur",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeSignature",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DateSignature",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileUrlsSigne",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "NomSignateur",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PrenomSignateur",
                table: "Documents");
        }
    }
}
