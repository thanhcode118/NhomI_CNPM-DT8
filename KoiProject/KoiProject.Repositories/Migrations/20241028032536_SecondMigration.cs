using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KoiProject.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95f239da-1c74-471d-b6ee-f04d0bdf1f06", null, "admin", "admin" },
                    { "9767cfc1-a9f2-4351-aeac-e77d7137108f", null, "judge", "contestant" },
                    { "dc8444c7-b393-42a4-b514-bdd34def7f91", null, "contestant", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f239da-1c74-471d-b6ee-f04d0bdf1f06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9767cfc1-a9f2-4351-aeac-e77d7137108f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc8444c7-b393-42a4-b514-bdd34def7f91");
        }
    }
}
