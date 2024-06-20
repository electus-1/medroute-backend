using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Changedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "7ca1c281-da10-4e7b-83e5-26c285bae765", "2", "Basic", "BASIC" },
                    { "e11828a2-e4dc-4c59-afa2-af2c8d27444d", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca1c281-da10-4e7b-83e5-26c285bae765");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e11828a2-e4dc-4c59-afa2-af2c8d27444d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10b62038-dc20-4e3a-8d45-6c8141940b75", "2", "Basic", "BASIC" },
                    { "3ade4fcc-29a9-41f9-a1da-8cf3a426d575", "1", "Admin", "ADMIN" }
                });
        }
    }
}
