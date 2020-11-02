using Microsoft.EntityFrameworkCore.Migrations;

namespace YourProjectName.Data.Migrations
{
    public partial class AddingServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlaneAvailable",
                table: "Planes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlaneAvailable",
                table: "Planes");
        }
    }
}
