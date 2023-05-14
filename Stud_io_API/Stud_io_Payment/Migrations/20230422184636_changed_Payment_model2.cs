using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io_Payment.Migrations
{
    public partial class changed_Payment_model2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Payments");
        }
    }
}
