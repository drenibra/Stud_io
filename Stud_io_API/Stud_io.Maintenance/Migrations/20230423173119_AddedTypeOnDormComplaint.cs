using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class AddedTypeOnDormComplaint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Complaints");
        }
    }
}
