using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class dbcontextmigrationtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_Role",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_Email",
                table: "ContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_Number",
                table: "ContactInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "EmployeeRole",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_Role",
                table: "EmployeeRole",
                column: "Role",
                unique: true,
                filter: "[Role] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_Email",
                table: "ContactInformation",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_Number",
                table: "ContactInformation",
                column: "Number",
                unique: true);
        }
    }
}
