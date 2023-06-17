using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Migrations
{
    /// <inheritdoc />
    public partial class latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FathersName",
                table: "AspNetUsers",
                newName: "ParentName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "AspNetUsers",
                newName: "FathersName");
        }
    }
}
