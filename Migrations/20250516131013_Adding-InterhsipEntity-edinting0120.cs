using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradAndInternship.Migrations
{
    /// <inheritdoc />
    public partial class AddingInterhsipEntityedinting0120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Phases_PhaseId",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProjectDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Phases_PhaseId",
                table: "Tasks",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Phases_PhaseId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Phases_PhaseId",
                table: "Tasks",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
