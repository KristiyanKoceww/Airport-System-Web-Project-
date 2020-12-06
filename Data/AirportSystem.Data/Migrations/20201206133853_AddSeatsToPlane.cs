using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportSystem.Data.Migrations
{
    public partial class AddSeatsToPlane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "SeatsCount",
                table: "Planes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    PlaneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_PlaneId",
                table: "Seat",
                column: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatsCount",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
