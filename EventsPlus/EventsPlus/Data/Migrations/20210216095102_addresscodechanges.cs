using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class addresscodechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AddressCode_AddressCodeID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode");

            migrationBuilder.DropIndex(
                name: "IX_Address_AddressCodeID",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "AddressCode",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "AddressCode",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AddressCode",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "IX_AddressCode_Postcode",
                table: "AddressCode");

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "AddressCode",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AddressCode",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode",
                column: "Postcode",
                unique: true);

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
    }
}
