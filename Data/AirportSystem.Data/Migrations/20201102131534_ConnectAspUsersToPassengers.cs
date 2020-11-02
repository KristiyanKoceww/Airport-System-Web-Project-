using Microsoft.EntityFrameworkCore.Migrations;

namespace YourProjectName.Data.Migrations
{
    public partial class ConnectAspUsersToPassengers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Passengers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PassengerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_PassengerId",
                table: "AspNetUsers",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PassengerId1",
                table: "AspNetUsers",
                column: "PassengerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId1",
                table: "AspNetUsers",
                column: "PassengerId1",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
