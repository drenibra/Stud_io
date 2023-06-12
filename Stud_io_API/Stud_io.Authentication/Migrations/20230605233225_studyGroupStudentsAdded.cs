using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Migrations
{
    /// <inheritdoc />
    public partial class studyGroupStudentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyGroupStudent_AspNetUsers_StudentId",
                table: "StudyGroupStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyGroupStudent",
                table: "StudyGroupStudent");

            migrationBuilder.RenameTable(
                name: "StudyGroupStudent",
                newName: "StudyGroupStudents");

            migrationBuilder.RenameIndex(
                name: "IX_StudyGroupStudent_StudentId",
                table: "StudyGroupStudents",
                newName: "IX_StudyGroupStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyGroupStudents",
                table: "StudyGroupStudents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyGroupStudents_AspNetUsers_StudentId",
                table: "StudyGroupStudents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyGroupStudents_AspNetUsers_StudentId",
                table: "StudyGroupStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyGroupStudents",
                table: "StudyGroupStudents");

            migrationBuilder.RenameTable(
                name: "StudyGroupStudents",
                newName: "StudyGroupStudent");

            migrationBuilder.RenameIndex(
                name: "IX_StudyGroupStudents_StudentId",
                table: "StudyGroupStudent",
                newName: "IX_StudyGroupStudent_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyGroupStudent",
                table: "StudyGroupStudent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyGroupStudent_AspNetUsers_StudentId",
                table: "StudyGroupStudent",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
