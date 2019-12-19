using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GQL.UserService.Migrations
{
    public partial class FixApiKeyRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ApiKeys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ApiKeys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "ApiKeys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "ApiKeys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ApiKeys");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "ApiKeys");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "ApiKeys");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "ApiKeys");
        }
    }
}
