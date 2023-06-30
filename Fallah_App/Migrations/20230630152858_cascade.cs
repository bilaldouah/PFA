using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerresId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_conseilTerresId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.RenameColumn(
                name: "conseilTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "ConseilTerreId");

            migrationBuilder.RenameColumn(
                name: "CategoryTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "CategoryTerreId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTerreConseilTerre_conseilTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "IX_CategoryTerreConseilTerre_ConseilTerreId");

            migrationBuilder.AlterColumn<string>(
                name: "TextFrancais",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerreId",
                table: "CategoryTerreConseilTerre",
                column: "CategoryTerreId",
                principalTable: "categoryTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_ConseilTerreId",
                table: "CategoryTerreConseilTerre",
                column: "ConseilTerreId",
                principalTable: "conseilTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerreId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_ConseilTerreId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.RenameColumn(
                name: "ConseilTerreId",
                table: "CategoryTerreConseilTerre",
                newName: "conseilTerresId");

            migrationBuilder.RenameColumn(
                name: "CategoryTerreId",
                table: "CategoryTerreConseilTerre",
                newName: "CategoryTerresId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTerreConseilTerre_ConseilTerreId",
                table: "CategoryTerreConseilTerre",
                newName: "IX_CategoryTerreConseilTerre_conseilTerresId");

            migrationBuilder.AlterColumn<string>(
                name: "TextFrancais",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerresId",
                table: "CategoryTerreConseilTerre",
                column: "CategoryTerresId",
                principalTable: "categoryTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_conseilTerresId",
                table: "CategoryTerreConseilTerre",
                column: "conseilTerresId",
                principalTable: "conseilTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
