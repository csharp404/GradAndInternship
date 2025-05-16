using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradAndInternship.Migrations
{
    /// <inheritdoc />
    public partial class AddingInterhsipEntityedinting01200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusDetails",
                table: "ProjectDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDetails",
                table: "ProjectDetails");
        }
    }
}
