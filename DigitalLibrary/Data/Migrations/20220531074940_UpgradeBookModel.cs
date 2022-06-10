using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalLibrary.Data.Migrations
{
    public partial class UpgradeBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Grades_GradeId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GradeId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Books",
                newName: "Grade5");

            migrationBuilder.AddColumn<int>(
                name: "Grade1",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grade2",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grade3",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grade4",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Grade2",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Grade3",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Grade4",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Grade5",
                table: "Books",
                newName: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GradeId",
                table: "Books",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Grades_GradeId",
                table: "Books",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
