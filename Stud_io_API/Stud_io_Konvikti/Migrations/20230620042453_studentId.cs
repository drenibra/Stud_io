using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Dormitory.Migrations
{
    /// <inheritdoc />
    public partial class studentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "studentId",
                table: "Questionnaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Questionnaires");
        }
    }
}
