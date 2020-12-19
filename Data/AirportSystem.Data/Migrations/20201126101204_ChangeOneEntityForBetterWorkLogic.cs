namespace AirportSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeOneEntityForBetterWorkLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_TravelLines_TravelLineCityId_TravelLineCity2Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TravelRoute",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "TravelLines",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityName2",
                table: "TravelLines",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Passports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Passports",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TravelLineCityId",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TravelLineCity2Id",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Flights",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TravelLineCity2Name",
                table: "Flights",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravelLineCityName",
                table: "Flights",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_TravelLines_TravelLineCityId_TravelLineCity2Id",
                table: "Flights",
                columns: new[] { "TravelLineCityId", "TravelLineCity2Id" },
                principalTable: "TravelLines",
                principalColumns: new[] { "CityId", "City2Id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_TravelLines_TravelLineCityId_TravelLineCity2Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "TravelLines");

            migrationBuilder.DropColumn(
                name: "CityName2",
                table: "TravelLines");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TravelLineCity2Name",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TravelLineCityName",
                table: "Flights");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TravelLineCityId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TravelLineCity2Id",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TravelRoute",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_TravelLines_TravelLineCityId_TravelLineCity2Id",
                table: "Flights",
                columns: new[] { "TravelLineCityId", "TravelLineCity2Id" },
                principalTable: "TravelLines",
                principalColumns: new[] { "CityId", "City2Id" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
