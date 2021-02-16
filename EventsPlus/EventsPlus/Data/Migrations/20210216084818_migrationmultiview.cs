using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class migrationmultiview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_Role",
                table: "EmployeeRole");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "EmployeeRole",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "AddressCode",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressCode_AddressID",
                table: "AddressCode",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode");

            migrationBuilder.DropIndex(
                name: "IX_AddressCode_AddressID",
                table: "AddressCode");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "AddressCode");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "EmployeeRole",
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
        }
    }
}
