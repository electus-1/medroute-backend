using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedRouter.WebApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class fixhotelidforeignkeyerroronroute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Hotel",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Hotels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Hospitals",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_HotelId",
                table: "Routes",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Hotel",
                table: "Routes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Hotel",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_HotelId",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Hotels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Hospitals",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Hotel",
                table: "Routes",
                column: "HospitalId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
