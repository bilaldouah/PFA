using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class wc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weather_Code",
                table: "conseilPlantes");

            migrationBuilder.AddColumn<string>(
                name: "Weather_Code",
                table: "conseilPlantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weather_Code",
                table: "conseilPlantes");

            migrationBuilder.AddColumn<int>(
                name: "Weather_Code",
                table: "conseilPlantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
