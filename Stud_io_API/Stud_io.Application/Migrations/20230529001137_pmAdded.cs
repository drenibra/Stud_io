using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Application.Migrations
{
    public partial class pmAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointsForGPA = table.Column<int>(type: "int", nullable: false),
                    PointsForCity = table.Column<int>(type: "int", nullable: false),
                    ExtraPoints = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileMatches_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatches_ApplicationId",
                table: "ProfileMatches",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileMatches");
        }
    }
}
