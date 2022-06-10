using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalLibrary.Data.Migrations
{
    public partial class UpgradeGradeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeValue",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeValue",
                table: "Grades");
        }
    }
}
