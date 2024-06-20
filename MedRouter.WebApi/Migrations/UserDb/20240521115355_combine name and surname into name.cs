using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class combinenameandsurnameintoname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019b0b7d-0b9c-4962-9524-324d36cd9828");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f07dc02a-c613-4109-bd6b-de78457cfbbe");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ApplicationUser",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32486424-fc57-4283-90eb-d8f89647b296", "1", "Admin", "ADMIN" },
                    { "d5eb779e-e988-4c9e-8b63-508b2c08fa0a", "2", "Basic", "BASIC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32486424-fc57-4283-90eb-d8f89647b296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5eb779e-e988-4c9e-8b63-508b2c08fa0a");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationUser",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ApplicationUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019b0b7d-0b9c-4962-9524-324d36cd9828", "2", "Basic", "BASIC" },
                    { "f07dc02a-c613-4109-bd6b-de78457cfbbe", "1", "Admin", "ADMIN" }
                });
        }
    }
}
