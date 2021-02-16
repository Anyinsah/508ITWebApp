using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class addresschange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressCodeID",
                table: "Address",
                column: "AddressCodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AddressCode_AddressCodeID",
                table: "Address",
                column: "AddressCodeID",
                principalTable: "AddressCode",
                principalColumn: "AddressCodeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AddressCode_AddressCodeID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_AddressCodeID",
                table: "Address");

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
    }
}
