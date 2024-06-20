using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "902839e0-a4b7-49c4-98f2-217e6e497ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeda304d-c351-4d59-8185-0d138315ab32");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a228eca-abde-4065-a6c1-aaadcf7fb1cf", "1", "Admin", "Admin" },
                    { "6ab68db4-8ed6-4219-8e8f-ea9b8023269a", "2", "Basic", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "902839e0-a4b7-49c4-98f2-217e6e497ac1", "2", "User", "User" },
                    { "aeda304d-c351-4d59-8185-0d138315ab32", "1", "Admin", "Admin" }
                });
        }
    }
}
