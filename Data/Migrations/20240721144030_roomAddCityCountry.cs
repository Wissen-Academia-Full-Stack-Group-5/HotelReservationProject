using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class roomAddCityCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 10,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 11,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 12,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 13,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 14,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 15,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 16,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 17,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 18,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 19,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 20,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 21,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 22,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 23,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 24,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 25,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 26,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 27,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 28,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 29,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 30,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 31,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 32,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 33,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 34,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 35,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 36,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 37,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 38,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 39,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 40,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 41,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 42,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 43,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 44,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 45,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 46,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 47,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 48,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 49,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 50,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 51,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 52,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 53,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 54,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 55,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 56,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 57,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 58,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 59,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 60,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 61,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 62,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 63,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 64,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 65,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 66,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 67,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 68,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 69,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 70,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 71,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 72,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 73,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 74,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 75,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 76,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 77,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 78,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 79,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 80,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 81,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 82,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 83,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 84,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 85,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 86,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 87,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 88,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 89,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 90,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 91,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 92,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 93,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 94,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 95,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 96,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 97,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 98,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 99,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 100,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 101,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 102,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 103,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 104,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 105,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 106,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 107,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 108,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 109,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 110,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 111,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 112,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 113,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 114,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 115,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 116,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 117,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 118,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 119,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 120,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 121,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 122,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 123,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 124,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 125,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 126,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 127,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 128,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 129,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 130,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 131,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 132,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 133,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 134,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 135,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 136,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 137,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 138,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 139,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 140,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 141,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 142,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 143,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 144,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 145,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 146,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 147,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 148,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 149,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 150,
                columns: new[] { "City", "Country" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Rooms");
        }
    }
}
