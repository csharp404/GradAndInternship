using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradAndInternship.Migrations
{
    /// <inheritdoc />
    public partial class AddingInterhsipEntityedinting01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Internships",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Internships",
                newName: "Name");
        }
    }
}
