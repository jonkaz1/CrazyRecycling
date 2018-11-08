using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Restructuredmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Bottle_BottleId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_CharacterClass_CharacterClassClassId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "RecyclingMachine");

            migrationBuilder.DropTable(
                name: "AttackEffect");

            migrationBuilder.DropIndex(
                name: "IX_Player_BottleId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_CharacterClassClassId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "BottleId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CharacterClassClassId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "NukeCola_Count",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Vodka_Damage",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Whiskey_Damage",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Wine_Damage",
                table: "Bottle");

            migrationBuilder.AlterColumn<int>(
                name: "PosY",
                table: "Player",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "PosX",
                table: "Player",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "CharacterClass",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SpawnTime",
                table: "Player",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BottleType",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectile",
                table: "Bottle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastPosX",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastPosY",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Bottle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    SizeX = table.Column<int>(nullable: false),
                    SizeY = table.Column<int>(nullable: false),
                    MachineType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottle_PlayerId",
                table: "Bottle",
                column: "PlayerId");

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

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Bottle_PlayerId",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "CharacterClass",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "SpawnTime",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "BottleType",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "IsProjectile",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "LastPosX",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "LastPosY",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Bottle");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Bottle");

            migrationBuilder.AlterColumn<double>(
                name: "PosY",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "PosX",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BottleId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterClassClassId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Bottle",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NukeCola_Count",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vodka_Damage",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Whiskey_Damage",
                table: "Bottle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wine_Damage",
                table: "Bottle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttackEffect",
                columns: table => new
                {
                    AttackEffectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackEffect", x => x.AttackEffectId);
                });

            migrationBuilder.CreateTable(
                name: "RecyclingMachine",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    SizeX = table.Column<int>(nullable: false),
                    SizeY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecyclingMachine", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Color = table.Column<int>(nullable: true),
                    Damage = table.Column<int>(nullable: true),
                    HealthPoints = table.Column<int>(nullable: true),
                    EffectAttackEffectId = table.Column<int>(nullable: true),
                    Hoarder_Color = table.Column<int>(nullable: true),
                    PointsBoost = table.Column<int>(nullable: true),
                    Speedy_HealthPoints = table.Column<int>(nullable: true),
                    Speed = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_CharacterClass_AttackEffect_EffectAttackEffectId",
                        column: x => x.EffectAttackEffectId,
                        principalTable: "AttackEffect",
                        principalColumn: "AttackEffectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_BottleId",
                table: "Player",
                column: "BottleId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CharacterClassClassId",
                table: "Player",
                column: "CharacterClassClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_EffectAttackEffectId",
                table: "CharacterClass",
                column: "EffectAttackEffectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Bottle_BottleId",
                table: "Player",
                column: "BottleId",
                principalTable: "Bottle",
                principalColumn: "BottleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_CharacterClass_CharacterClassClassId",
                table: "Player",
                column: "CharacterClassClassId",
                principalTable: "CharacterClass",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
