using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirusTracker.Migrations
{
    public partial class ModifiedPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    messageContent = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(maxLength: 40, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    address = table.Column<string>(maxLength: 60, nullable: true),
                    phoneNumber = table.Column<string>(maxLength: 13, nullable: false),
                    emailAddress = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    weight = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    symptomsDate = table.Column<DateTime>(nullable: false),
                    symptoms = table.Column<string>(nullable: false),
                    additionalComments = table.Column<string>(maxLength: 600, nullable: true),
                    treatment = table.Column<string>(maxLength: 600, nullable: true),
                    treatmentComments = table.Column<string>(maxLength: 600, nullable: true),
                    doctorId = table.Column<string>(nullable: true),
                    quarantineEndDate = table.Column<DateTime>(nullable: false),
                    messages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_AspNetUsers_doctorId",
                        column: x => x.doctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_doctorId",
                table: "Patient",
                column: "doctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
