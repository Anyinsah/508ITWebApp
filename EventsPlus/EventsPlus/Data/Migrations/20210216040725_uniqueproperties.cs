using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class uniqueproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressCode_Postcode",
                table: "AddressCode");

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

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "AddressCode",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode",
                column: "Postcode",
                unique: true,
                filter: "[Postcode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode");

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

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "AddressCode",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressCode_Postcode",
                table: "AddressCode",
                column: "Postcode");
        }
    }
}
