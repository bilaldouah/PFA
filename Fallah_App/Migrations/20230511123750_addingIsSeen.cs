using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class addingIsSeen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgriculteurNotification_notifications_NotificationsId",
                table: "AgriculteurNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_AgriculteurNotification_users_AgriculteursId",
                table: "AgriculteurNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgriculteurNotification",
                table: "AgriculteurNotification");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationsId",
                table: "AgriculteurNotification",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "AgriculteursId",
                table: "AgriculteurNotification",
                newName: "AgriculteurId");

            migrationBuilder.RenameIndex(
                name: "IX_AgriculteurNotification_NotificationsId",
                table: "AgriculteurNotification",
                newName: "IX_AgriculteurNotification_NotificationId");

            migrationBuilder.AlterColumn<string>(
                name: "TextArabe",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AgriculteurNotification",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "AgriculteurNotification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgriculteurNotification",
                table: "AgriculteurNotification",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AgriculteurNotification_AgriculteurId",
                table: "AgriculteurNotification",
                column: "AgriculteurId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_AgriculteurNotification_AgriculteurId",
                table: "AgriculteurNotification");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AgriculteurNotification");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "AgriculteurNotification");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "AgriculteurNotification",
                newName: "NotificationsId");

            migrationBuilder.RenameColumn(
                name: "AgriculteurId",
                table: "AgriculteurNotification",
                newName: "AgriculteursId");

            migrationBuilder.RenameIndex(
                name: "IX_AgriculteurNotification_NotificationId",
                table: "AgriculteurNotification",
                newName: "IX_AgriculteurNotification_NotificationsId");

            migrationBuilder.AlterColumn<string>(
                name: "TextArabe",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgriculteurNotification",
                table: "AgriculteurNotification",
                columns: new[] { "AgriculteursId", "NotificationsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AgriculteurNotification_notifications_NotificationsId",
                table: "AgriculteurNotification",
                column: "NotificationsId",
                principalTable: "notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgriculteurNotification_users_AgriculteursId",
                table: "AgriculteurNotification",
                column: "AgriculteursId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
