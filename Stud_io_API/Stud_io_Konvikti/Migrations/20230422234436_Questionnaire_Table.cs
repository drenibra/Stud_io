using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io_Dormitory.Migrations
{
    public partial class Questionnaire_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shareBelongings = table.Column<bool>(type: "bit", nullable: false),
                    sleepingHabits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    havingGuests = table.Column<bool>(type: "bit", nullable: false),
                    roomCleanliness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionnaires");
        }
    }
}
