using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Occupency", "Rate" },
                values: new object[] { "First Villa", 130, 104342125.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Occupency", "Rate", "Sqft" },
                values: new object[,]
                {
                    { 2, "Connection was successfully established with the server, but then an error occurred duri", "Dummy", "Second Villa", 1430, 104342125.0, 1024 },
                    { 3, "Connection was successfully established with the server, but then an error occurred duri", "Dummy", "Third Villa", 1530, 1742125.0, 1024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Occupency", "Rate" },
                values: new object[] { "Test", 10, 102125.0 });
        }
    }
}
