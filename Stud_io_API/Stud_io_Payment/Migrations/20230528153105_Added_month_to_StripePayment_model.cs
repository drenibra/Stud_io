using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io_Payment.Migrations
{
    public partial class Added_month_to_StripePayment_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "StripePayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "StripePayments");
        }
    }
}
