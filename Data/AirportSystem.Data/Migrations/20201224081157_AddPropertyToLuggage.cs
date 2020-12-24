using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSystem.Data.Migrations
{
    public partial class AddPropertyToLuggage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassengerFirstName",
                table: "Luggage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerFirstName",
                table: "Luggage");
        }
    }
}
