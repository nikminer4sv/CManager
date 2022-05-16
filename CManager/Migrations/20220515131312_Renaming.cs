using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CManager.Migrations
{
    public partial class Renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72efd3c1-01ea-4435-bd6f-a7fa5791c3f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cedb3007-e42d-4749-b0f8-c583a6c2f030");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "NickName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b586bd02-c312-40e1-8998-77668e46f2a2", "697f48a8-3836-4936-81e7-21fa68cde20c", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d86eb643-0827-4eec-b256-7a89a274e647", "af4cc7fc-b300-4716-ba35-4345a01fe414", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b586bd02-c312-40e1-8998-77668e46f2a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86eb643-0827-4eec-b256-7a89a274e647");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72efd3c1-01ea-4435-bd6f-a7fa5791c3f3", "c00f14f0-3702-4efb-aa39-fcec7e8abc76", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cedb3007-e42d-4749-b0f8-c583a6c2f030", "b12a1d2d-24bb-437d-9185-c65352f43aee", "admin", null });
        }
    }
}
