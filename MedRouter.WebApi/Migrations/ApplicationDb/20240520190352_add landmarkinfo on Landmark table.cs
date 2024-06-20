using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedRouter.WebApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class addlandmarkinfoonLandmarktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LandmarkInfo",
                table: "Landmarks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandmarkInfo",
                table: "Landmarks");
        }
    }
}
