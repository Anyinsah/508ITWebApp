using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "AddressCode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "AddressCode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCode_Address_AddressID",
                table: "AddressCode",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
