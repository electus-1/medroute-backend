using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedRouter.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addprivelegetousertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3821e9-9804-4a7b-8b4b-c58250632340");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecf5bec0-df38-4d72-a4e6-8ebb22a8f2ba");

            migrationBuilder.AddColumn<string>(
                name: "Privilege",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Privilege",
                table: "ApplicationUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bb3821e9-9804-4a7b-8b4b-c58250632340", "1", "Admin", "ADMIN" },
                    { "ecf5bec0-df38-4d72-a4e6-8ebb22a8f2ba", "2", "Basic", "BASIC" }
                });
        }
    }
}
