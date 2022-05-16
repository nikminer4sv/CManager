using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CManager.Migrations
{
    public partial class LikeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28bde772-5e81-4ad0-93cb-6e3e984a102e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d14ed5-d34a-4ea8-9289-64c6c144c4b1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3332d929-dbf0-467e-8315-2d298977d7d6", "3c37e00a-0481-404a-9fa9-1f1b5fdd2275", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f3a68f0-0690-47cc-8a05-2bfdffdaa2aa", "99db97f4-88e1-46b1-8e09-05b4112410c0", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3332d929-dbf0-467e-8315-2d298977d7d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3a68f0-0690-47cc-8a05-2bfdffdaa2aa");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28bde772-5e81-4ad0-93cb-6e3e984a102e", "18d71890-d547-4a15-987e-6b817659e5b1", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92d14ed5-d34a-4ea8-9289-64c6c144c4b1", "ceac3aee-0a9e-40eb-b18b-9a69ed5c1d42", "user", "USER" });
        }
    }
}
