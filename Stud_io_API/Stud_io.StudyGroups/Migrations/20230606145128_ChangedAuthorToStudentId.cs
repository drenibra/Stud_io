using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.StudyGroups.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAuthorToStudentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Resources",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comments",
                newName: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Resources",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Comments",
                newName: "AuthorId");
        }
    }
}
