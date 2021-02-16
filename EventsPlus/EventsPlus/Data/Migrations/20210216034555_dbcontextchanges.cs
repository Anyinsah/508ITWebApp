using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class dbcontextchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressCode",
                columns: table => new
                {
                    AddressCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCode", x => x.AddressCodeID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    ContactInformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.ContactInformationID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    EmployeeRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.EmployeeRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_AddressCode_AddressCodeID",
                        column: x => x.AddressCodeID,
                        principalTable: "AddressCode",
                        principalColumn: "AddressCodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCompany",
                columns: table => new
                {
                    EventCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ContactInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCompany", x => x.EventCompanyID);
                    table.ForeignKey(
                        name: "FK_EventCompany_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCompany_ContactInformation_ContactInformationID",
                        column: x => x.ContactInformationID,
                        principalTable: "ContactInformation",
                        principalColumn: "ContactInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ContactInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_ContactInformation_ContactInformationID",
                        column: x => x.ContactInformationID,
                        principalTable: "ContactInformation",
                        principalColumn: "ContactInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSchedule",
                columns: table => new
                {
                    EventScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventCompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSchedule", x => x.EventScheduleID);
                    table.ForeignKey(
                        name: "FK_EventSchedule_EventCompany_EventCompanyID",
                        column: x => x.EventCompanyID,
                        principalTable: "EventCompany",
                        principalColumn: "EventCompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeRole_EmployeeRoleID",
                        column: x => x.EmployeeRoleID,
                        principalTable: "EmployeeRole",
                        principalColumn: "EmployeeRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventScheduleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_EventSchedule_EventScheduleID",
                        column: x => x.EventScheduleID,
                        principalTable: "EventSchedule",
                        principalColumn: "EventScheduleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    AttendeeID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Attendee_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressCodeID",
                table: "Address",
                column: "AddressCodeID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_EventID",
                table: "Attendee",
                column: "EventID");

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
                name: "IX_Employee_EmployeeRoleID",
                table: "Employee",
                column: "EmployeeRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_Role",
                table: "EmployeeRole",
                column: "Role",
                unique: true,
                filter: "[Role] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventScheduleID",
                table: "Event",
                column: "EventScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_EventCompany_AddressID",
                table: "EventCompany",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_EventCompany_ContactInformationID",
                table: "EventCompany",
                column: "ContactInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_EventSchedule_EventCompanyID",
                table: "EventSchedule",
                column: "EventCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressID",
                table: "Person",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContactInformationID",
                table: "Person",
                column: "ContactInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventID",
                table: "Ticket",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventSchedule");

            migrationBuilder.DropTable(
                name: "EventCompany");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "AddressCode");
        }
    }
}
