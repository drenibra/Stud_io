using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Dormitory.Migrations
{
    public partial class AddCapacityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Dormitories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isFull",
                table: "Dormitories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Dormitories");

            migrationBuilder.DropColumn(
                name: "isFull",
                table: "Dormitories");
        }
    }
}
