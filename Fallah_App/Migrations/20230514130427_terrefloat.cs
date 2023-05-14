using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class terrefloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgriculteurNotification_notifications_NotificationId",
                table: "AgriculteurNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_AgriculteurNotification_users_AgriculteurId",
                table: "AgriculteurNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgriculteurNotification",
                table: "AgriculteurNotification");

            migrationBuilder.RenameTable(
                name: "AgriculteurNotification",
                newName: "agriculteurNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_AgriculteurNotification_NotificationId",
                table: "agriculteurNotifications",
                newName: "IX_agriculteurNotifications_NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_AgriculteurNotification_AgriculteurId",
                table: "agriculteurNotifications",
                newName: "IX_agriculteurNotifications_AgriculteurId");

            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "terres",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "latitude",
                table: "terres",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agriculteurNotifications",
                table: "agriculteurNotifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_agriculteurNotifications_notifications_NotificationId",
                table: "agriculteurNotifications",
                column: "NotificationId",
                principalTable: "notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agriculteurNotifications_users_AgriculteurId",
                table: "agriculteurNotifications",
                column: "AgriculteurId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agriculteurNotifications_notifications_NotificationId",
                table: "agriculteurNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_agriculteurNotifications_users_AgriculteurId",
                table: "agriculteurNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agriculteurNotifications",
                table: "agriculteurNotifications");

            migrationBuilder.RenameTable(
                name: "agriculteurNotifications",
                newName: "AgriculteurNotification");

            migrationBuilder.RenameIndex(
                name: "IX_agriculteurNotifications_NotificationId",
                table: "AgriculteurNotification",
                newName: "IX_AgriculteurNotification_NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_agriculteurNotifications_AgriculteurId",
                table: "AgriculteurNotification",
                newName: "IX_AgriculteurNotification_AgriculteurId");

            migrationBuilder.AlterColumn<int>(
                name: "longitude",
                table: "terres",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "latitude",
                table: "terres",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgriculteurNotification",
                table: "AgriculteurNotification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgriculteurNotification_notifications_NotificationId",
                table: "AgriculteurNotification",
                column: "NotificationId",
                principalTable: "notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgriculteurNotification_users_AgriculteurId",
                table: "AgriculteurNotification",
                column: "AgriculteurId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
