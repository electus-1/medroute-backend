using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32486424-fc57-4283-90eb-d8f89647b296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5eb779e-e988-4c9e-8b63-508b2c08fa0a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "549d7e36-9acb-42c4-8f73-f77b9f6fe282", "1", "Admin", "ADMIN" },
                    { "e1ed2f0e-07b9-434a-9a7e-6dfe4c28c264", "2", "Basic", "BASIC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "549d7e36-9acb-42c4-8f73-f77b9f6fe282");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ed2f0e-07b9-434a-9a7e-6dfe4c28c264");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32486424-fc57-4283-90eb-d8f89647b296", "1", "Admin", "ADMIN" },
                    { "d5eb779e-e988-4c9e-8b63-508b2c08fa0a", "2", "Basic", "BASIC" }
                });
        }
    }
}
