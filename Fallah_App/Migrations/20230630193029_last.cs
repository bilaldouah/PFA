using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "ConseilTerresId");

            migrationBuilder.RenameColumn(
                name: "CategoryTerreId",
                table: "CategoryTerreConseilTerre",
                newName: "CategoryTerresId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTerreConseilTerre_ConseilTerreId",
                table: "CategoryTerreConseilTerre",
                newName: "IX_CategoryTerreConseilTerre_ConseilTerresId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerresId",
                table: "CategoryTerreConseilTerre",
                column: "CategoryTerresId",
                principalTable: "categoryTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_ConseilTerresId",
                table: "CategoryTerreConseilTerre",
                column: "ConseilTerresId",
                principalTable: "conseilTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerresId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTerreConseilTerre_conseilTerres_ConseilTerresId",
                table: "CategoryTerreConseilTerre");

            migrationBuilder.RenameColumn(
                name: "ConseilTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "ConseilTerreId");

            migrationBuilder.RenameColumn(
                name: "CategoryTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "CategoryTerreId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTerreConseilTerre_ConseilTerresId",
                table: "CategoryTerreConseilTerre",
                newName: "IX_CategoryTerreConseilTerre_ConseilTerreId");

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
    }
}
