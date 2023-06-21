using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class addedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializimet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializimet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semundjet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializimiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semundjet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semundjet_Specializimet_SpecializimiId",
                        column: x => x.SpecializimiId,
                        principalTable: "Specializimet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semundjet_SpecializimiId",
                table: "Semundjet",
                column: "SpecializimiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Semundjet");

            migrationBuilder.DropTable(
                name: "Specializimet");
        }
    }
}
