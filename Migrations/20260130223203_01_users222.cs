using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackend.Migrations
{
    /// <inheritdoc />
    public partial class _01_users222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7e3c8d3c-8123-48fc-838b-743f2e0a86d1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a7fe7eca-aea1-4106-b3d6-39e7fee135b9");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "326c89dc-d096-4884-b32f-a8254147b563", null, "Admin", "ADMIN" },
                    { "e0696b96-1164-44ed-978c-68564eb962b3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "326c89dc-d096-4884-b32f-a8254147b563");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e0696b96-1164-44ed-978c-68564eb962b3");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e3c8d3c-8123-48fc-838b-743f2e0a86d1", null, "User", "USER" },
                    { "a7fe7eca-aea1-4106-b3d6-39e7fee135b9", null, "Admin", "ADMIN" }
                });
        }
    }
}
