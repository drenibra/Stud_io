using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io_Payment.Migrations
{
    public partial class Deleted_some_Stripe_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddStripeCustomers");

            migrationBuilder.DropTable(
                name: "AddStripePayments");

            migrationBuilder.DropTable(
                name: "AddStripeCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddStripeCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cvc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddStripeCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddStripePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddStripePayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddStripeCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddStripeCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddStripeCustomers_AddStripeCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "AddStripeCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddStripeCustomers_CreditCardId",
                table: "AddStripeCustomers",
                column: "CreditCardId");
        }
    }
}
