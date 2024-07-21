using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class hjghjg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country1",
                table: "Rooms",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "City1",
                table: "Rooms",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Rooms",
                newName: "Country1");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Rooms",
                newName: "City1");
        }
    }
}
