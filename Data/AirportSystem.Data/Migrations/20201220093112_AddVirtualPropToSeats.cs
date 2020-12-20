using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSystem.Data.Migrations
{
    public partial class AddVirtualPropToSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlaneId",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlaneId",
                table: "Seats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
