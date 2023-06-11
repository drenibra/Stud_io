using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.StudyGroups.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateTimeEndGroupEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "GroupEvents");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "GroupEvents",
                newName: "DateTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEnd",
                table: "GroupEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "GroupEvents");

            migrationBuilder.RenameColumn(
                name: "DateTimeStart",
                table: "GroupEvents",
                newName: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "GroupEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
