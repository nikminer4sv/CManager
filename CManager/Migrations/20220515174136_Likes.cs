using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CManager.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b586bd02-c312-40e1-8998-77668e46f2a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86eb643-0827-4eec-b256-7a89a274e647");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28bde772-5e81-4ad0-93cb-6e3e984a102e", "18d71890-d547-4a15-987e-6b817659e5b1", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92d14ed5-d34a-4ea8-9289-64c6c144c4b1", "ceac3aee-0a9e-40eb-b18b-9a69ed5c1d42", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28bde772-5e81-4ad0-93cb-6e3e984a102e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d14ed5-d34a-4ea8-9289-64c6c144c4b1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b586bd02-c312-40e1-8998-77668e46f2a2", "697f48a8-3836-4936-81e7-21fa68cde20c", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d86eb643-0827-4eec-b256-7a89a274e647", "af4cc7fc-b300-4716-ba35-4345a01fe414", "admin", null });
        }
    }
}
