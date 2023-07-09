using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class notifterredelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationTerre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationTerre",
                columns: table => new
                {
                    notificationsId = table.Column<int>(type: "int", nullable: false),
                    terresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTerre", x => new { x.notificationsId, x.terresId });
                    table.ForeignKey(
                        name: "FK_NotificationTerre_notifications_notificationsId",
                        column: x => x.notificationsId,
                        principalTable: "notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationTerre_terres_terresId",
                        column: x => x.terresId,
                        principalTable: "terres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTerre_terresId",
                table: "NotificationTerre",
                column: "terresId");
        }
    }
}
