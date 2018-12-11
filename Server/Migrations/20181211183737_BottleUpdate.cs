using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class BottleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottle_Player_PlayerId",
                table: "Bottle");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Bottle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bottle_Player_PlayerId",
                table: "Bottle",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottle_Player_PlayerId",
                table: "Bottle");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Bottle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bottle_Player_PlayerId",
                table: "Bottle",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
