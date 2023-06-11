using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.StudyGroups.Migrations
{
    /// <inheritdoc />
    public partial class AddedNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEvents_StudyGroups_StudyGroupId",
                table: "GroupEvents");

            migrationBuilder.DropColumn(
                name: "GroupSettingsId",
                table: "StudyGroups");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StudyGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StudyGroupId",
                table: "GroupEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEvents_StudyGroups_StudyGroupId",
                table: "GroupEvents",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEvents_StudyGroups_StudyGroupId",
                table: "GroupEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StudyGroups");

            migrationBuilder.AddColumn<int>(
                name: "GroupSettingsId",
                table: "StudyGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudyGroupId",
                table: "GroupEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEvents_StudyGroups_StudyGroupId",
                table: "GroupEvents",
                column: "StudyGroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id");
        }
    }
}
