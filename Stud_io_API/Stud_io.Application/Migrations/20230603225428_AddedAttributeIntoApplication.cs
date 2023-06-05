using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Application.Migrations
{
    public partial class AddedAttributeIntoApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentsId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Applications");
        }
    }
}
