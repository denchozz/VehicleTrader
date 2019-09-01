using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTrader.App.Migrations
{
    public partial class DealerImgUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dealers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dealers");
        }
    }
}
