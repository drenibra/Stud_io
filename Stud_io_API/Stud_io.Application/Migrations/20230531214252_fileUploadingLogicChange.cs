using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Application.Migrations
{
    public partial class fileUploadingLogicChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_FileDetails_FileId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_FileId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_FileId",
                table: "Applications",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_FileDetails_FileId",
                table: "Applications",
                column: "FileId",
                principalTable: "FileDetails",
                principalColumn: "ID");
        }
    }
}
