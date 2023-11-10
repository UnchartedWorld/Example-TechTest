using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotivWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableApplication",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicantTitle = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantName = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantPhoneNum = table.Column<int>(type: "INTEGER", nullable: true),
                    ApplicantAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApplicantDepositAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfRepayYears = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableApplication", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "TableDrivingLicense",
                columns: table => new
                {
                    DrivingLicenseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrivingLicenseName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDrivingLicense", x => x.DrivingLicenseID);
                });

            migrationBuilder.CreateTable(
                name: "TableFinanceOptions",
                columns: table => new
                {
                    FinanceOptionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinanceLoanRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinLoanAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxLoanAmount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFinanceOptions", x => x.FinanceOptionID);
                });

            migrationBuilder.CreateTable(
                name: "TableMaritalStatus",
                columns: table => new
                {
                    MaritalStatusID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaritalStatusName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableMaritalStatus", x => x.MaritalStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TableAppInputRelations",
                columns: table => new
                {
                    AppInputRelationsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationID = table.Column<int>(type: "INTEGER", nullable: false),
                    DrivingLicenseID = table.Column<int>(type: "INTEGER", nullable: false),
                    MaritalStatusID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAppInputRelations", x => x.AppInputRelationsID);
                    table.ForeignKey(
                        name: "FK_TableAppInputRelations_TableApplication_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "TableApplication",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAppInputRelations_TableDrivingLicense_DrivingLicenseID",
                        column: x => x.DrivingLicenseID,
                        principalTable: "TableDrivingLicense",
                        principalColumn: "DrivingLicenseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAppInputRelations_TableMaritalStatus_MaritalStatusID",
                        column: x => x.MaritalStatusID,
                        principalTable: "TableMaritalStatus",
                        principalColumn: "MaritalStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableAppInputRelations_ApplicationID",
                table: "TableAppInputRelations",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAppInputRelations_DrivingLicenseID",
                table: "TableAppInputRelations",
                column: "DrivingLicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_TableAppInputRelations_MaritalStatusID",
                table: "TableAppInputRelations",
                column: "MaritalStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableAppInputRelations");

            migrationBuilder.DropTable(
                name: "TableFinanceOptions");

            migrationBuilder.DropTable(
                name: "TableApplication");

            migrationBuilder.DropTable(
                name: "TableDrivingLicense");

            migrationBuilder.DropTable(
                name: "TableMaritalStatus");
        }
    }
}
