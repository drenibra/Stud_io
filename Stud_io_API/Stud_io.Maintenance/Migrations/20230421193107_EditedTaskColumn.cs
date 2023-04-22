using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class EditedTaskColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Tasks",
                newName: "IsCompleted");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Tasks",
                newName: "IsDeleted");
        }
    }
}
