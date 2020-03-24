﻿// <auto-generated />
using System;
using DbTableEditor.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbTableEditor.AspNetApp.Migrations
{
    [DbContext(typeof(SpaceshipsContext))]
    [Migration("20200318120558_Populate with data")]
    partial class Populatewithdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DbTableEditor.Data.Model.Alliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("Power")
                        .HasColumnName("power")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("alliances_name_uindex");

                    b.ToTable("alliances");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.AlliancesEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('alliance_entries_id_seq'::regclass)");

                    b.Property<int>("AllianceId")
                        .HasColumnName("alliance_id")
                        .HasColumnType("integer");

                    b.Property<int>("EmpireId")
                        .HasColumnName("empire_id")
                        .HasColumnType("integer");

                    b.Property<int>("EntryYear")
                        .HasColumnName("entry_year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmpireId");

                    b.HasIndex("AllianceId", "EmpireId")
                        .IsUnique()
                        .HasName("alliance_entries_alliance_id_empire_id_uindex");

                    b.ToTable("alliances_entries");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Commander", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnName("age")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("RankId")
                        .HasColumnName("rank_id")
                        .HasColumnType("integer");

                    b.Property<int>("Skill")
                        .HasColumnName("skill")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.ToTable("commanders");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Empire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GovernmentTypeId")
                        .HasColumnName("government_type_id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("Power")
                        .HasColumnName("power")
                        .HasColumnType("integer");

                    b.Property<string>("Ruler")
                        .HasColumnName("ruler")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentTypeId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("empires_name_uindex");

                    b.ToTable("empires");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Fleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CommanderId")
                        .HasColumnName("commander_id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("StatusId")
                        .HasColumnName("status_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CommanderId")
                        .IsUnique()
                        .HasName("fleets_commander_id_uindex");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("fleets_name_uindex");

                    b.HasIndex("StatusId");

                    b.ToTable("fleets");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.GovernmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("government_types_name_uindex");

                    b.ToTable("government_types");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Approval")
                        .HasColumnName("approval")
                        .HasColumnType("integer");

                    b.Property<int?>("EmpireId")
                        .HasColumnName("empire_id")
                        .HasColumnType("integer");

                    b.Property<int>("Habitability")
                        .HasColumnName("habitability")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<long>("Population")
                        .HasColumnName("population")
                        .HasColumnType("bigint");

                    b.Property<int>("Size")
                        .HasColumnName("size")
                        .HasColumnType("integer");

                    b.Property<int>("StarId")
                        .HasColumnName("star_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmpireId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("planets_name_uindex");

                    b.HasIndex("StarId");

                    b.ToTable("planets");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("ranks_name_uindex");

                    b.ToTable("ranks");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Shipyard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("Pipelines")
                        .HasColumnName("pipelines")
                        .HasColumnType("integer");

                    b.Property<int>("PlanetId")
                        .HasColumnName("planet_id")
                        .HasColumnType("integer");

                    b.Property<int>("Staff")
                        .HasColumnName("staff")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("shipyards_name_uindex");

                    b.HasIndex("PlanetId")
                        .IsUnique()
                        .HasName("shipyards_planet_id_uindex");

                    b.ToTable("shipyards");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Spaceship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacity")
                        .HasColumnName("capacity")
                        .HasColumnType("integer");

                    b.Property<int>("Energy")
                        .HasColumnName("energy")
                        .HasColumnType("integer");

                    b.Property<int>("Firepower")
                        .HasColumnName("firepower")
                        .HasColumnType("integer");

                    b.Property<int>("FleetId")
                        .HasColumnName("fleet_id")
                        .HasColumnType("integer");

                    b.Property<int>("Fuel")
                        .HasColumnName("fuel")
                        .HasColumnType("integer");

                    b.Property<int>("Hull")
                        .HasColumnName("hull")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("ShipyardId")
                        .HasColumnName("shipyard_id")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnName("speed")
                        .HasColumnType("integer");

                    b.Property<int>("Staff")
                        .HasColumnName("staff")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnName("weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("spaceships_name_uindex");

                    b.HasIndex("ShipyardId");

                    b.ToTable("spaceships");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("Age")
                        .HasColumnName("age")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int>("Size")
                        .HasColumnName("size")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("stars_name_uindex");

                    b.HasIndex("TypeId");

                    b.ToTable("stars");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.StarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("star_types_name_uindex");

                    b.ToTable("star_types");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("statuses_name_uindex");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.AlliancesEntry", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Alliance", "Alliance")
                        .WithMany("AlliancesEntries")
                        .HasForeignKey("AllianceId")
                        .HasConstraintName("alliance_entries_alliances_id_fk")
                        .IsRequired();

                    b.HasOne("DbTableEditor.Data.Model.Empire", "Empire")
                        .WithMany("AlliancesEntries")
                        .HasForeignKey("EmpireId")
                        .HasConstraintName("alliance_entries_empires_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Commander", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Rank", "Rank")
                        .WithMany("Commanders")
                        .HasForeignKey("RankId")
                        .HasConstraintName("commanders_ranks_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Empire", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.GovernmentType", "GovernmentType")
                        .WithMany("Empires")
                        .HasForeignKey("GovernmentTypeId")
                        .HasConstraintName("empires_government_types_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Fleet", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Commander", "Commander")
                        .WithOne("Fleet")
                        .HasForeignKey("DbTableEditor.Data.Model.Fleet", "CommanderId")
                        .HasConstraintName("fleets_commanders_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbTableEditor.Data.Model.Status", "Status")
                        .WithMany("Fleets")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("fleets___fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Planet", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Empire", "Empire")
                        .WithMany("Planets")
                        .HasForeignKey("EmpireId")
                        .HasConstraintName("planets_empires_id_fk");

                    b.HasOne("DbTableEditor.Data.Model.Star", "Star")
                        .WithMany("Planets")
                        .HasForeignKey("StarId")
                        .HasConstraintName("planets_stars_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Shipyard", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Planet", "Planet")
                        .WithOne("Shipyards")
                        .HasForeignKey("DbTableEditor.Data.Model.Shipyard", "PlanetId")
                        .HasConstraintName("shipyards_planets_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Spaceship", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.Fleet", "Fleet")
                        .WithMany("Spaceships")
                        .HasForeignKey("FleetId")
                        .HasConstraintName("spaceships_fleets_id_fk")
                        .IsRequired();

                    b.HasOne("DbTableEditor.Data.Model.Shipyard", "Shipyard")
                        .WithMany("Spaceships")
                        .HasForeignKey("ShipyardId")
                        .HasConstraintName("spaceships_shipyards_id_fk")
                        .IsRequired();
                });

            modelBuilder.Entity("DbTableEditor.Data.Model.Star", b =>
                {
                    b.HasOne("DbTableEditor.Data.Model.StarType", "Type")
                        .WithMany("Stars")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("stars_star_types_id_fk")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}