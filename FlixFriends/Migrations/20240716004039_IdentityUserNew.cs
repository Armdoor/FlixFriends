using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlixFriends.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84a3d8f0-6af9-4da9-a504-844b28b778f9", null, "User", "USER" },
                    { "c7dba0c1-8ecb-428e-923e-98aeaec82ca1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84a3d8f0-6af9-4da9-a504-844b28b778f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7dba0c1-8ecb-428e-923e-98aeaec82ca1");
        }
    }
}
