using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackend.Migrations
{
    /// <inheritdoc />
    public partial class _01_users22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "481b3832-5d38-4246-8404-4ed778ebbb80");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d2e44313-dafa-4b84-9278-c11c595ae8c7");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7e3c8d3c-8123-48fc-838b-743f2e0a86d1", null, "User", "USER" },
                    { "a7fe7eca-aea1-4106-b3d6-39e7fee135b9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "481b3832-5d38-4246-8404-4ed778ebbb80", null, "Admin", "ADMIN" },
                    { "d2e44313-dafa-4b84-9278-c11c595ae8c7", null, "User", "USER" }
                });
        }
    }
}
