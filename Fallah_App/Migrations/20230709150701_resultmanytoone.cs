using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class resultmanytoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_resultats_Id_ConseilPlante",
                table: "resultats");

            migrationBuilder.AddColumn<int>(
                name: "CategoryTerreId",
                table: "resultats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_resultats_CategoryTerreId",
                table: "resultats",
                column: "CategoryTerreId");

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_ConseilPlante",
                table: "resultats",
                column: "Id_ConseilPlante");

            migrationBuilder.AddForeignKey(
                name: "FK_resultats_categoryTerres_CategoryTerreId",
                table: "resultats",
                column: "CategoryTerreId",
                principalTable: "categoryTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resultats_categoryTerres_CategoryTerreId",
                table: "resultats");

            migrationBuilder.DropIndex(
                name: "IX_resultats_CategoryTerreId",
                table: "resultats");

            migrationBuilder.DropIndex(
                name: "IX_resultats_Id_ConseilPlante",
                table: "resultats");

            migrationBuilder.DropColumn(
                name: "CategoryTerreId",
                table: "resultats");

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_ConseilPlante",
                table: "resultats",
                column: "Id_ConseilPlante",
                unique: true,
                filter: "[Id_ConseilPlante] IS NOT NULL");
        }
    }
}
