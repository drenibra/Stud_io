using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.StudyGroups.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentNameInCommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Comments");
        }
    }
}
