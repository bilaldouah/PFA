﻿// <auto-generated />
using System;
using Fallah_App.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fallah_App.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryTerreConseilTerre", b =>
                {
                    b.Property<int>("CategoryTerresId")
                        .HasColumnType("int");

                    b.Property<int>("ConseilTerresId")
                        .HasColumnType("int");

                    b.HasKey("CategoryTerresId", "ConseilTerresId");

                    b.HasIndex("ConseilTerresId");

                    b.ToTable("CategoryTerreConseilTerre");
                });

            modelBuilder.Entity("ConseilPlantePlante", b =>
                {
                    b.Property<int>("conseilPlantesId")
                        .HasColumnType("int");

                    b.Property<int>("plantesId")
                        .HasColumnType("int");

                    b.HasKey("conseilPlantesId", "plantesId");

                    b.HasIndex("plantesId");

                    b.ToTable("ConseilPlantePlante");
                });

            modelBuilder.Entity("Fallah_App.Models.AgriculteurNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgriculteurId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<int?>("webmasterid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgriculteurId");

                    b.HasIndex("NotificationId");

                    b.HasIndex("webmasterid");

                    b.ToTable("agriculteurNotifications");
                });

            modelBuilder.Entity("Fallah_App.Models.CategoryTerre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Attribut_De_Categorisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valeur_Max")
                        .HasColumnType("float");

                    b.Property<double>("Valeur_Min")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("categoryTerres");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilPlante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_De_Creation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_De_Modification")
                        .HasColumnType("datetime2");

                    b.Property<double>("Humidite_Max")
                        .HasColumnType("float");

                    b.Property<double>("Humidite_Min")
                        .HasColumnType("float");

                    b.Property<int>("Id_WebMaster")
                        .HasColumnType("int");

                    b.Property<double>("Quantite_Eau")
                        .HasColumnType("float");

                    b.Property<string>("Resultat_Attendue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Temperature_Max")
                        .HasColumnType("float");

                    b.Property<double>("Temperature_Min")
                        .HasColumnType("float");

                    b.Property<string>("Text_Arabe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text_Francais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Vent_Max")
                        .HasColumnType("float");

                    b.Property<double>("Vent_Min")
                        .HasColumnType("float");

                    b.Property<int>("Weather_Code")
                        .HasColumnType("int");

                    b.Property<string>("audio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nbr_Modif")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_WebMaster");

                    b.ToTable("conseilPlantes");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilTerre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Audio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_WebMaster")
                        .HasColumnType("int");

                    b.Property<string>("Text_Arabe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text_Francais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_WebMaster");

                    b.ToTable("conseilTerres");
                });

            modelBuilder.Entity("Fallah_App.Models.Demande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_De_Naissance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Demande")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_WebMaster")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("forme")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_WebMaster");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("Fallah_App.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Id_WebMaster")
                        .HasColumnType("int");

                    b.Property<string>("TextArabe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextFrancais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_WebMaster");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Fallah_App.Models.Plante", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Debut_Period")
                        .HasColumnType("int");

                    b.Property<int>("Fin_Date")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("plantes");
                });

            modelBuilder.Entity("Fallah_App.Models.Resultat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_De_Saisie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_ConseilPlante")
                        .HasColumnType("int");

                    b.Property<int?>("Id_ConseilTerre")
                        .HasColumnType("int");

                    b.Property<int>("Id_agriculteurForme")
                        .HasColumnType("int");

                    b.Property<int>("Statut_Favorable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_ConseilPlante");

                    b.HasIndex("Id_ConseilTerre");

                    b.HasIndex("Id_agriculteurForme");

                    b.ToTable("resultats");
                });

            modelBuilder.Entity("Fallah_App.Models.Sol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Acidite")
                        .HasColumnType("float");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sols");
                });

            modelBuilder.Entity("Fallah_App.Models.Terre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Agriculteur")
                        .HasColumnType("int");

                    b.Property<int>("Id_categoryTerre")
                        .HasColumnType("int");

                    b.Property<double>("Surface")
                        .HasColumnType("float");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Agriculteur");

                    b.HasIndex("Id_categoryTerre");

                    b.ToTable("terres");
                });

            modelBuilder.Entity("Fallah_App.Models.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("Date_Dernier_Auth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NotificationPlante", b =>
                {
                    b.Property<int>("PlantesId")
                        .HasColumnType("int");

                    b.Property<int>("notificationsId")
                        .HasColumnType("int");

                    b.HasKey("PlantesId", "notificationsId");

                    b.HasIndex("notificationsId");

                    b.ToTable("NotificationPlante");
                });

            modelBuilder.Entity("PlanteTerre", b =>
                {
                    b.Property<int>("plantesId")
                        .HasColumnType("int");

                    b.Property<int>("terresId")
                        .HasColumnType("int");

                    b.HasKey("plantesId", "terresId");

                    b.HasIndex("terresId");

                    b.ToTable("PlanteTerre");
                });

            modelBuilder.Entity("SolTerre", b =>
                {
                    b.Property<int>("solsId")
                        .HasColumnType("int");

                    b.Property<int>("terresId")
                        .HasColumnType("int");

                    b.HasKey("solsId", "terresId");

                    b.HasIndex("terresId");

                    b.ToTable("SolTerre");
                });

            modelBuilder.Entity("Fallah_App.Models.Agriculteur", b =>
                {
                    b.HasBaseType("Fallah_App.Models.User");

                    b.Property<DateTime>("Date_Creation_Compte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_De_Naissance")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Agriculteur");
                });

            modelBuilder.Entity("Fallah_App.Models.WebMaster", b =>
                {
                    b.HasBaseType("Fallah_App.Models.User");

                    b.HasDiscriminator().HasValue("Webmaster");
                });

            modelBuilder.Entity("Fallah_App.Models.AgriculteurForme", b =>
                {
                    b.HasBaseType("Fallah_App.Models.Agriculteur");

                    b.HasDiscriminator().HasValue("AgriculteurForme");
                });

            modelBuilder.Entity("CategoryTerreConseilTerre", b =>
                {
                    b.HasOne("Fallah_App.Models.CategoryTerre", null)
                        .WithMany()
                        .HasForeignKey("CategoryTerresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.ConseilTerre", null)
                        .WithMany()
                        .HasForeignKey("ConseilTerresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ConseilPlantePlante", b =>
                {
                    b.HasOne("Fallah_App.Models.ConseilPlante", null)
                        .WithMany()
                        .HasForeignKey("conseilPlantesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.Plante", null)
                        .WithMany()
                        .HasForeignKey("plantesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fallah_App.Models.AgriculteurNotification", b =>
                {
                    b.HasOne("Fallah_App.Models.Agriculteur", "Agriculteur")
                        .WithMany("AgriculteurNotifications")
                        .HasForeignKey("AgriculteurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.Notification", "Notification")
                        .WithMany("AgriculteurNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.WebMaster", "webMaster")
                        .WithMany()
                        .HasForeignKey("webmasterid")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Agriculteur");

                    b.Navigation("Notification");

                    b.Navigation("webMaster");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilPlante", b =>
                {
                    b.HasOne("Fallah_App.Models.WebMaster", "webMaster")
                        .WithMany("conseilPlantes")
                        .HasForeignKey("Id_WebMaster")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("webMaster");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilTerre", b =>
                {
                    b.HasOne("Fallah_App.Models.WebMaster", "webMaster")
                        .WithMany("conseilTerres")
                        .HasForeignKey("Id_WebMaster")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("webMaster");
                });

            modelBuilder.Entity("Fallah_App.Models.Demande", b =>
                {
                    b.HasOne("Fallah_App.Models.WebMaster", "webMaster")
                        .WithMany("DemandeList")
                        .HasForeignKey("Id_WebMaster")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("webMaster");
                });

            modelBuilder.Entity("Fallah_App.Models.Notification", b =>
                {
                    b.HasOne("Fallah_App.Models.WebMaster", "webMaster")
                        .WithMany("notifications")
                        .HasForeignKey("Id_WebMaster")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("webMaster");
                });

            modelBuilder.Entity("Fallah_App.Models.Resultat", b =>
                {
                    b.HasOne("Fallah_App.Models.ConseilPlante", "ConseilPlante")
                        .WithMany("resultat")
                        .HasForeignKey("Id_ConseilPlante")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Fallah_App.Models.ConseilTerre", "ConseilTerre")
                        .WithMany("resultats")
                        .HasForeignKey("Id_ConseilTerre")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Fallah_App.Models.AgriculteurForme", "agriculteurForme")
                        .WithMany("resultats")
                        .HasForeignKey("Id_agriculteurForme")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConseilPlante");

                    b.Navigation("ConseilTerre");

                    b.Navigation("agriculteurForme");
                });

            modelBuilder.Entity("Fallah_App.Models.Terre", b =>
                {
                    b.HasOne("Fallah_App.Models.Agriculteur", "Agriculteur")
                        .WithMany("Terres")
                        .HasForeignKey("Id_Agriculteur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.CategoryTerre", "categoryTerre")
                        .WithMany("terres")
                        .HasForeignKey("Id_categoryTerre")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agriculteur");

                    b.Navigation("categoryTerre");
                });

            modelBuilder.Entity("NotificationPlante", b =>
                {
                    b.HasOne("Fallah_App.Models.Plante", null)
                        .WithMany()
                        .HasForeignKey("PlantesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.Notification", null)
                        .WithMany()
                        .HasForeignKey("notificationsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanteTerre", b =>
                {
                    b.HasOne("Fallah_App.Models.Plante", null)
                        .WithMany()
                        .HasForeignKey("plantesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.Terre", null)
                        .WithMany()
                        .HasForeignKey("terresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SolTerre", b =>
                {
                    b.HasOne("Fallah_App.Models.Sol", null)
                        .WithMany()
                        .HasForeignKey("solsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fallah_App.Models.Terre", null)
                        .WithMany()
                        .HasForeignKey("terresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fallah_App.Models.CategoryTerre", b =>
                {
                    b.Navigation("terres");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilPlante", b =>
                {
                    b.Navigation("resultat");
                });

            modelBuilder.Entity("Fallah_App.Models.ConseilTerre", b =>
                {
                    b.Navigation("resultats");
                });

            modelBuilder.Entity("Fallah_App.Models.Notification", b =>
                {
                    b.Navigation("AgriculteurNotifications");
                });

            modelBuilder.Entity("Fallah_App.Models.Agriculteur", b =>
                {
                    b.Navigation("AgriculteurNotifications");

                    b.Navigation("Terres");
                });

            modelBuilder.Entity("Fallah_App.Models.WebMaster", b =>
                {
                    b.Navigation("DemandeList");

                    b.Navigation("conseilPlantes");

                    b.Navigation("conseilTerres");

                    b.Navigation("notifications");
                });

            modelBuilder.Entity("Fallah_App.Models.AgriculteurForme", b =>
                {
                    b.Navigation("resultats");
                });
#pragma warning restore 612, 618
        }
    }
}
