using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradAndInternship.Migrations
{
    /// <inheritdoc />
    public partial class ishdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDetails_Students_StudentId",
                table: "ProjectDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_StudentId",
                table: "ProjectDetails");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ProjectDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProjectId",
                table: "Students",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ProjectDetails_ProjectId",
                table: "Students",
                column: "ProjectId",
                principalTable: "ProjectDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ProjectDetails_ProjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "ProjectDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_StudentId",
                table: "ProjectDetails",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDetails_Students_StudentId",
                table: "ProjectDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
