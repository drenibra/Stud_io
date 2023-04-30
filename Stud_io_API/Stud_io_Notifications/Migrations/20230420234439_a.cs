using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io_Notifications.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeadlineId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_DeadlineId",
                table: "Announcements",
                column: "DeadlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Deadlines_DeadlineId",
                table: "Announcements",
                column: "DeadlineId",
                principalTable: "Deadlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Deadlines_DeadlineId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_DeadlineId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "DeadlineId",
                table: "Announcements");
        }
    }
}
