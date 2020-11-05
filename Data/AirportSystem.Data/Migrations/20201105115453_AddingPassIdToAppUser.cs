using Microsoft.EntityFrameworkCore.Migrations;

namespace YourProjectName.Data.Migrations
{
    public partial class AddingPassIdToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PassengerId1",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassengerId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PassengerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PassengerId",
                table: "AspNetUsers",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId",
                table: "AspNetUsers",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
