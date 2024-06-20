using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeroleagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a228eca-abde-4065-a6c1-aaadcf7fb1cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab68db4-8ed6-4219-8e8f-ea9b8023269a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10b62038-dc20-4e3a-8d45-6c8141940b75", "2", "Basic", "BASIC" },
                    { "3ade4fcc-29a9-41f9-a1da-8cf3a426d575", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10b62038-dc20-4e3a-8d45-6c8141940b75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ade4fcc-29a9-41f9-a1da-8cf3a426d575");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a228eca-abde-4065-a6c1-aaadcf7fb1cf", "1", "Admin", "Admin" },
                    { "6ab68db4-8ed6-4219-8e8f-ea9b8023269a", "2", "Basic", "User" }
                });
        }
    }
}
