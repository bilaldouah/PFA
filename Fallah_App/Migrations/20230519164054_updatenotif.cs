using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class updatenotif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Dernier_Auth",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "terres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "terres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "webmasterid",
                table: "agriculteurNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_agriculteurNotifications_webmasterid",
                table: "agriculteurNotifications",
                column: "webmasterid");

            migrationBuilder.AddForeignKey(
                name: "FK_agriculteurNotifications_users_webmasterid",
                table: "agriculteurNotifications",
                column: "webmasterid",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agriculteurNotifications_users_webmasterid",
                table: "agriculteurNotifications");

            migrationBuilder.DropIndex(
                name: "IX_agriculteurNotifications_webmasterid",
                table: "agriculteurNotifications");

            migrationBuilder.DropColumn(
                name: "type",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "webmasterid",
                table: "agriculteurNotifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Dernier_Auth",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "terres",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "latitude",
                table: "terres",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
