using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Refactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Player");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckTime",
                table: "Player",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCheckTime",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Player",
                nullable: false,
                defaultValue: 0);
        }
    }
}
