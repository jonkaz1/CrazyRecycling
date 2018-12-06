using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthPoints",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BagDeepness",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BagPosition",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUseTime",
                table: "Bottle",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthPoints",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "BagDeepness",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "BagPosition",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "LastUseTime",
                table: "Bottle");
        }
    }
}
