using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class updateTerre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hauteur",
                table: "terres");

            migrationBuilder.DropColumn(
                name: "Humidite",
                table: "terres");

            migrationBuilder.DropColumn(
                name: "Localisation",
                table: "terres");

            migrationBuilder.AddColumn<int>(
                name: "latitude",
                table: "terres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "longitude",
                table: "terres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "terres");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "terres");

            migrationBuilder.AddColumn<double>(
                name: "Hauteur",
                table: "terres",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Humidite",
                table: "terres",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Localisation",
                table: "terres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
