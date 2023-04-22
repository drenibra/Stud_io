using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stud_io.Maintenance.Migrations
{
    /// <inheritdoc />
    public partial class AddedComplaintModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscontentComplaints");

            migrationBuilder.DropTable(
                name: "DormComplaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialComplaints",
                table: "SocialComplaints");

            migrationBuilder.RenameTable(
                name: "SocialComplaints",
                newName: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "ComplainedRoomNo",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FloorNo",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "FloorNo",
                table: "Complaints");

            migrationBuilder.RenameTable(
                name: "Complaints",
                newName: "SocialComplaints");

            migrationBuilder.AlterColumn<int>(
                name: "ComplainedRoomNo",
                table: "SocialComplaints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialComplaints",
                table: "SocialComplaints",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DiscontentComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DormNo = table.Column<int>(type: "int", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscontentComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DormComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DormNo = table.Column<int>(type: "int", nullable: false),
                    FloorNo = table.Column<int>(type: "int", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DormComplaints", x => x.Id);
                });
        }
    }
}
