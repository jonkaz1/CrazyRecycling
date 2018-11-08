using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddedBottlePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Bottle",
                columns: table => new
                {
                    BottleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    SpawnTime = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: true),
                    Damage = table.Column<int>(nullable: true),
                    NukeCola_Count = table.Column<int>(nullable: true),
                    Vodka_Damage = table.Column<int>(nullable: true),
                    Whiskey_Damage = table.Column<int>(nullable: true),
                    Wine_Damage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottle", x => x.BottleId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    HealthPoints = table.Column<int>(nullable: true),
                    Damage = table.Column<int>(nullable: true),
                    Color = table.Column<int>(nullable: true),
                    EffectAttackEffectId = table.Column<int>(nullable: true),
                    PointsBoost = table.Column<int>(nullable: true),
                    Hoarder_Color = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PosX = table.Column<double>(nullable: false),
                    PosY = table.Column<double>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    BottleId = table.Column<int>(nullable: true),
                    Color = table.Column<int>(nullable: false),
                    CharacterClassClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Bottle_BottleId",
                        column: x => x.BottleId,
                        principalTable: "Bottle",
                        principalColumn: "BottleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_CharacterClass_CharacterClassClassId",
                        column: x => x.CharacterClassClassId,
                        principalTable: "CharacterClass",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_EffectAttackEffectId",
                table: "CharacterClass",
                column: "EffectAttackEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_BottleId",
                table: "Player",
                column: "BottleId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CharacterClassClassId",
                table: "Player",
                column: "CharacterClassClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Bottle");

            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "AttackEffect");
        }
    }
}
