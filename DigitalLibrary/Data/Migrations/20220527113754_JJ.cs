using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalLibrary.Data.Migrations
{
    public partial class JJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BookTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookTypeID",
                table: "Books",
                newName: "BookTypeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Books",
                newName: "BookTypId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookTypeID",
                table: "Books",
                newName: "IX_Books_BookTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookTypes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BookTypeId",
                table: "Books",
                newName: "BookTypeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BookTypId",
                table: "Books",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookTypeId",
                table: "Books",
                newName: "IX_Books_BookTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeID",
                table: "Books",
                column: "BookTypeID",
                principalTable: "BookTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
