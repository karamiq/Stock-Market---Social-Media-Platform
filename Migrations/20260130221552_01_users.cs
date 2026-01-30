using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackend.Migrations
{
    /// <inheritdoc />
    public partial class _01_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1f4bef07-bb38-4a79-ade4-1771425cbe33");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "76585c5e-fa0d-474a-89f6-c4393648abd0");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1658cc87-cdde-4455-841d-3e4aa73fabf3", null, "Admin", "ADMIN" },
                    { "803c4d96-0cbf-41f0-90f6-f936884e8b83", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1f4bef07-bb38-4a79-ade4-1771425cbe33", null, "Admin", "ADMIN" },
                    { "76585c5e-fa0d-474a-89f6-c4393648abd0", null, "User", "USER" }
                });
        }
    }
}
