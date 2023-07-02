using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class result1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_ConseilTerre",
                table: "resultats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_ConseilTerre",
                table: "resultats",
                column: "Id_ConseilTerre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_resultats_conseilTerres_Id_ConseilTerre",
                table: "resultats",
                column: "Id_ConseilTerre",
                principalTable: "conseilTerres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "resultatId",
                table: "conseilTerres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_conseilTerres_resultatId",
                table: "conseilTerres",
                column: "resultatId");

            migrationBuilder.AddForeignKey(
                name: "FK_conseilTerres_resultats_resultatId",
                table: "conseilTerres",
                column: "resultatId",
                principalTable: "resultats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
