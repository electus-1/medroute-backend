using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedRouter.WebApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ApplicationUser",
                newName: "Privilege");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "ApplicationUser",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Privilege",
                table: "ApplicationUser",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationUser",
                newName: "FirstName");
        }
    }
}
