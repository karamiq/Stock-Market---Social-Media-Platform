using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackend.Migrations
{
    /// <inheritdoc />
    public partial class _01_users2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1658cc87-cdde-4455-841d-3e4aa73fabf3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "803c4d96-0cbf-41f0-90f6-f936884e8b83");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "481b3832-5d38-4246-8404-4ed778ebbb80", null, "Admin", "ADMIN" },
                    { "d2e44313-dafa-4b84-9278-c11c595ae8c7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1658cc87-cdde-4455-841d-3e4aa73fabf3", null, "Admin", "ADMIN" },
                    { "803c4d96-0cbf-41f0-90f6-f936884e8b83", null, "User", "USER" }
                });
        }
    }
}
