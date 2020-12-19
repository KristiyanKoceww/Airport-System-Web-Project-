namespace AirportSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddAmountOnPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");
        }
    }
}
