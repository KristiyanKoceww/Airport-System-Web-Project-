using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSystem.Data.Migrations
{
    public partial class RewritePlanePropertySeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsCount",
                table: "Planes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatsCount",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
