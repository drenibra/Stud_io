using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class EditedComplaintColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FloorNumber",
                table: "Tasks",
                newName: "FloorNo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Complaints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Complaints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "FloorNo",
                table: "Tasks",
                newName: "FloorNumber");
        }
    }
}
