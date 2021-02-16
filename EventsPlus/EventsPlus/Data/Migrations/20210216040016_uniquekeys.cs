using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class uniquekeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressCode_County",
                table: "AddressCode");

            migrationBuilder.DropIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode");

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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressCode_Postcode",
                table: "AddressCode",
                column: "Postcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressCode_Postcode",
                table: "AddressCode");

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
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressCode_County",
                table: "AddressCode",
                column: "County",
                unique: true,
                filter: "[County] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCode_Postcode",
                table: "AddressCode",
                column: "Postcode",
                unique: true,
                filter: "[Postcode] IS NOT NULL");
        }
    }
}
