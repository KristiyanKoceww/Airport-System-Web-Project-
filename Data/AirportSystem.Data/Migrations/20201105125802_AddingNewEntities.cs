using Microsoft.EntityFrameworkCore.Migrations;

namespace YourProjectName.Data.Migrations
{
    public partial class AddingNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_AspNetUsers_UserId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Passengers");

            migrationBuilder.AddColumn<string>(
                name: "AvioCompanyId",
                table: "Planes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirportId",
                table: "Flights",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersPassengers",
                columns: table => new
                {
                    PassengerId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPassengers", x => new { x.PassengerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersPassengers_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPassengers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvioCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    AirportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvioCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvioCompanies_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_AvioCompanyId",
                table: "Planes",
                column: "AvioCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityId",
                table: "Airports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AvioCompanies_AirportId",
                table: "AvioCompanies",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPassengers_UserId",
                table: "UsersPassengers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_AvioCompanies_AvioCompanyId",
                table: "Planes",
                column: "AvioCompanyId",
                principalTable: "AvioCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_AvioCompanies_AvioCompanyId",
                table: "Planes");

            migrationBuilder.DropTable(
                name: "AvioCompanies");

            migrationBuilder.DropTable(
                name: "UsersPassengers");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Planes_AvioCompanyId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AvioCompanyId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_AspNetUsers_UserId",
                table: "Passengers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
