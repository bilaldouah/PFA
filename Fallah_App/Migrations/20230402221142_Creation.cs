using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fallah_App.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryTerres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribut_De_Categorisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valeur_Max = table.Column<double>(type: "float", nullable: false),
                    Valeur_Min = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTerres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debut_Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acidite = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Dernier_Auth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    Date_De_Naissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Creation_Compte = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conseilPlantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text_Arabe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text_Francais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite_Eau = table.Column<double>(type: "float", nullable: false),
                    Date_De_Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_De_Modification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nbr_Modif = table.Column<int>(type: "int", nullable: false),
                    Resultat_Attendue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature_Max = table.Column<double>(type: "float", nullable: false),
                    Temperature_Min = table.Column<double>(type: "float", nullable: false),
                    Humidite_Max = table.Column<double>(type: "float", nullable: false),
                    Humidite_Min = table.Column<double>(type: "float", nullable: false),
                    Vent_Max = table.Column<double>(type: "float", nullable: false),
                    Vent_Min = table.Column<double>(type: "float", nullable: false),
                    Weather_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_WebMaster = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conseilPlantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conseilPlantes_users_Id_WebMaster",
                        column: x => x.Id_WebMaster,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conseilTerres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text_Arabe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text_Francais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_WebMaster = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conseilTerres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conseilTerres_users_Id_WebMaster",
                        column: x => x.Id_WebMaster,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_De_Naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Demande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    Id_WebMaster = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_demandes_users_Id_WebMaster",
                        column: x => x.Id_WebMaster,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    TextArabe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFrancais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_WebMaster = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_users_Id_WebMaster",
                        column: x => x.Id_WebMaster,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "terres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Humidite = table.Column<double>(type: "float", nullable: false),
                    Hauteur = table.Column<double>(type: "float", nullable: false),
                    Surface = table.Column<double>(type: "float", nullable: false),
                    Id_Agriculteur = table.Column<int>(type: "int", nullable: false),
                    Id_categoryTerre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_terres_categoryTerres_Id_categoryTerre",
                        column: x => x.Id_categoryTerre,
                        principalTable: "categoryTerres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_terres_users_Id_Agriculteur",
                        column: x => x.Id_Agriculteur,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConseilPlantePlante",
                columns: table => new
                {
                    conseilPlantesId = table.Column<int>(type: "int", nullable: false),
                    plantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConseilPlantePlante", x => new { x.conseilPlantesId, x.plantesId });
                    table.ForeignKey(
                        name: "FK_ConseilPlantePlante_conseilPlantes_conseilPlantesId",
                        column: x => x.conseilPlantesId,
                        principalTable: "conseilPlantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConseilPlantePlante_plantes_plantesId",
                        column: x => x.plantesId,
                        principalTable: "plantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resultats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_De_Saisie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut_Favorable = table.Column<bool>(type: "bit", nullable: false),
                    Id_ConseilPlante = table.Column<int>(type: "int", nullable: false),
                    Id_agriculteurForme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resultats_conseilPlantes_Id_ConseilPlante",
                        column: x => x.Id_ConseilPlante,
                        principalTable: "conseilPlantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resultats_users_Id_agriculteurForme",
                        column: x => x.Id_agriculteurForme,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTerreConseilTerre",
                columns: table => new
                {
                    CategoryTerresId = table.Column<int>(type: "int", nullable: false),
                    conseilTerresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTerreConseilTerre", x => new { x.CategoryTerresId, x.conseilTerresId });
                    table.ForeignKey(
                        name: "FK_CategoryTerreConseilTerre_categoryTerres_CategoryTerresId",
                        column: x => x.CategoryTerresId,
                        principalTable: "categoryTerres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTerreConseilTerre_conseilTerres_conseilTerresId",
                        column: x => x.conseilTerresId,
                        principalTable: "conseilTerres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgriculteurNotification",
                columns: table => new
                {
                    AgriculteursId = table.Column<int>(type: "int", nullable: false),
                    NotificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculteurNotification", x => new { x.AgriculteursId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_AgriculteurNotification_notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriculteurNotification_users_AgriculteursId",
                        column: x => x.AgriculteursId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationPlante",
                columns: table => new
                {
                    PlantesId = table.Column<int>(type: "int", nullable: false),
                    notificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationPlante", x => new { x.PlantesId, x.notificationsId });
                    table.ForeignKey(
                        name: "FK_NotificationPlante_notifications_notificationsId",
                        column: x => x.notificationsId,
                        principalTable: "notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationPlante_plantes_PlantesId",
                        column: x => x.PlantesId,
                        principalTable: "plantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "PlanteTerre",
                columns: table => new
                {
                    plantesId = table.Column<int>(type: "int", nullable: false),
                    terresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanteTerre", x => new { x.plantesId, x.terresId });
                    table.ForeignKey(
                        name: "FK_PlanteTerre_plantes_plantesId",
                        column: x => x.plantesId,
                        principalTable: "plantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanteTerre_terres_terresId",
                        column: x => x.terresId,
                        principalTable: "terres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolTerre",
                columns: table => new
                {
                    solsId = table.Column<int>(type: "int", nullable: false),
                    terresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolTerre", x => new { x.solsId, x.terresId });
                    table.ForeignKey(
                        name: "FK_SolTerre_sols_solsId",
                        column: x => x.solsId,
                        principalTable: "sols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolTerre_terres_terresId",
                        column: x => x.terresId,
                        principalTable: "terres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriculteurNotification_NotificationsId",
                table: "AgriculteurNotification",
                column: "NotificationsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTerreConseilTerre_conseilTerresId",
                table: "CategoryTerreConseilTerre",
                column: "conseilTerresId");

            migrationBuilder.CreateIndex(
                name: "IX_ConseilPlantePlante_plantesId",
                table: "ConseilPlantePlante",
                column: "plantesId");

            migrationBuilder.CreateIndex(
                name: "IX_conseilPlantes_Id_WebMaster",
                table: "conseilPlantes",
                column: "Id_WebMaster");

            migrationBuilder.CreateIndex(
                name: "IX_conseilTerres_Id_WebMaster",
                table: "conseilTerres",
                column: "Id_WebMaster");

            migrationBuilder.CreateIndex(
                name: "IX_demandes_Id_WebMaster",
                table: "demandes",
                column: "Id_WebMaster");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPlante_notificationsId",
                table: "NotificationPlante",
                column: "notificationsId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_Id_WebMaster",
                table: "notifications",
                column: "Id_WebMaster");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTerre_terresId",
                table: "NotificationTerre",
                column: "terresId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanteTerre_terresId",
                table: "PlanteTerre",
                column: "terresId");

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_agriculteurForme",
                table: "resultats",
                column: "Id_agriculteurForme");

            migrationBuilder.CreateIndex(
                name: "IX_resultats_Id_ConseilPlante",
                table: "resultats",
                column: "Id_ConseilPlante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolTerre_terresId",
                table: "SolTerre",
                column: "terresId");

            migrationBuilder.CreateIndex(
                name: "IX_terres_Id_Agriculteur",
                table: "terres",
                column: "Id_Agriculteur");

            migrationBuilder.CreateIndex(
                name: "IX_terres_Id_categoryTerre",
                table: "terres",
                column: "Id_categoryTerre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriculteurNotification");

            migrationBuilder.DropTable(
                name: "CategoryTerreConseilTerre");

            migrationBuilder.DropTable(
                name: "ConseilPlantePlante");

            migrationBuilder.DropTable(
                name: "demandes");

            migrationBuilder.DropTable(
                name: "NotificationPlante");

            migrationBuilder.DropTable(
                name: "NotificationTerre");

            migrationBuilder.DropTable(
                name: "PlanteTerre");

            migrationBuilder.DropTable(
                name: "resultats");

            migrationBuilder.DropTable(
                name: "SolTerre");

            migrationBuilder.DropTable(
                name: "conseilTerres");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "plantes");

            migrationBuilder.DropTable(
                name: "conseilPlantes");

            migrationBuilder.DropTable(
                name: "sols");

            migrationBuilder.DropTable(
                name: "terres");

            migrationBuilder.DropTable(
                name: "categoryTerres");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
