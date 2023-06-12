using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Dormitory.Migrations
{
    public partial class ResetIdentityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DBCC CHECKIDENT ('Rooms', RESEED, 0);");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
