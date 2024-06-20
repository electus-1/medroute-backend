using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class reEstablishusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1459979b-8e81-4c4f-8636-0f062015e0ed", "2", "Basic", "BASIC" },
                    { "ceaf77a9-0e05-483a-a641-ba2c32f76b16", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1459979b-8e81-4c4f-8636-0f062015e0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceaf77a9-0e05-483a-a641-ba2c32f76b16");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ca1c281-da10-4e7b-83e5-26c285bae765", "2", "Basic", "BASIC" },
                    { "e11828a2-e4dc-4c59-afa2-af2c8d27444d", "1", "Admin", "ADMIN" }
                });
        }
    }
}
