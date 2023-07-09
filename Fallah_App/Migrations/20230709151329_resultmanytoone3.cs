using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class resultmanytoone3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resultats_categoryTerres_CategoryTerreId",
                table: "resultats");

            migrationBuilder.DropIndex(
                name: "IX_resultats_CategoryTerreId",
                table: "resultats");

            migrationBuilder.DropIndex(
                name: "IX_resultats_Id_ConseilTerre",
                table: "resultats");

            migrationBuilder.DropColumn(
                name: "CategoryTerreId",
                table: "resultats");

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_ConseilTerre",
                table: "resultats",
                column: "Id_ConseilTerre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_resultats_Id_ConseilTerre",
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
                name: "IX_resultats_Id_ConseilTerre",
                table: "resultats",
                column: "Id_ConseilTerre",
                unique: true,
                filter: "[Id_ConseilTerre] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_resultats_categoryTerres_CategoryTerreId",
                table: "resultats",
                column: "CategoryTerreId",
                principalTable: "categoryTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
