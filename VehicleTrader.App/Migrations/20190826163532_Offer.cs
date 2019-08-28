using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTrader.App.Migrations
{
    public partial class Offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechDatas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    EngineType = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    Transmission = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    OfferId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechDatas_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechDatas_OfferId",
                table: "TechDatas",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechDatas");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
