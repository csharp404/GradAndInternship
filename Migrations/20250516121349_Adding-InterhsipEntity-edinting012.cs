using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradAndInternship.Migrations
{
    /// <inheritdoc />
    public partial class AddingInterhsipEntityedinting012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternshipAcceptToDoctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterGraduate = table.Column<int>(type: "int", nullable: false),
                    SemesterInternship = table.Column<int>(type: "int", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfInternship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipAcceptToDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipAcceptToDoctors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsInternshipDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipAcceptToDoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsInternshipDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsInternshipDays_InternshipAcceptToDoctors_InternshipAcceptToDoctorId",
                        column: x => x.InternshipAcceptToDoctorId,
                        principalTable: "InternshipAcceptToDoctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternshipAcceptToDoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phases_InternshipAcceptToDoctors_InternshipAcceptToDoctorId",
                        column: x => x.InternshipAcceptToDoctorId,
                        principalTable: "InternshipAcceptToDoctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternshipAcceptToDoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_InternshipAcceptToDoctors_InternshipAcceptToDoctorId",
                        column: x => x.InternshipAcceptToDoctorId,
                        principalTable: "InternshipAcceptToDoctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsInternshipDays_InternshipAcceptToDoctorId",
                table: "DetailsInternshipDays",
                column: "InternshipAcceptToDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipAcceptToDoctors_StudentId",
                table: "InternshipAcceptToDoctors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_InternshipAcceptToDoctorId",
                table: "Phases",
                column: "InternshipAcceptToDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InternshipAcceptToDoctorId",
                table: "Reports",
                column: "InternshipAcceptToDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PhaseId",
                table: "Tasks",
                column: "PhaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsInternshipDays");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "InternshipAcceptToDoctors");
        }
    }
}
