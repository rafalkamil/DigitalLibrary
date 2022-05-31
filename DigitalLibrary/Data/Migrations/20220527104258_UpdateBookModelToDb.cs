using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalLibrary.Data.Migrations
{
    public partial class UpdateBookModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_TypeId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TypeId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookTypeID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeID",
                table: "Books",
                column: "BookTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books",
                column: "BookTypeID",
                principalTable: "BookTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypeID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookTypeID",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TypeId",
                table: "Books",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_TypeId",
                table: "Books",
                column: "TypeId",
                principalTable: "BookTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
