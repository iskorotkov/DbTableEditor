using DbTableEditor.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DbTableEditor.Data.Context
{
    public partial class SpaceshipsContext : DbContext
    {
        public SpaceshipsContext()
        {
        }

        public SpaceshipsContext(DbContextOptions<SpaceshipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alliance> Alliances { get; set; }

        public virtual DbSet<AlliancesEntry> AlliancesEntries { get; set; }

        public virtual DbSet<Commander> Commanders { get; set; }

        public virtual DbSet<Empire> Empires { get; set; }

        public virtual DbSet<Fleet> Fleets { get; set; }

        public virtual DbSet<GovernmentType> GovernmentTypes { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Rank> Ranks { get; set; }

        public virtual DbSet<Shipyard> Shipyards { get; set; }

        public virtual DbSet<Spaceship> Spaceships { get; set; }

        public virtual DbSet<StarType> StarTypes { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Statuses> Statuses { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified);

            var errors = new List<ValidationResult>();
            foreach (var e in entries)
            {
                var ctx = new ValidationContext(e.Entity);
                Validator.TryValidateObject(e.Entity, ctx, errors, validateAllProperties: true);
            }

            if (errors.Count > 0)
            {
                throw new Exceptions.ValidationException(errors);
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
                var password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
                optionsBuilder.UseNpgsql($"Host=localhost;Database=spaceships;Username={username};Password={password}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alliance>(entity =>
            {
                entity.ToTable("alliances");

                entity.HasIndex(e => e.Name)
                    .HasName("alliances_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Power).HasColumnName("power");
            });

            modelBuilder.Entity<AlliancesEntry>(entity =>
            {
                entity.ToTable("alliances_entries");

                entity.HasIndex(e => new { e.AllianceId, e.EmpireId })
                    .HasName("alliance_entries_alliance_id_empire_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('alliance_entries_id_seq'::regclass)");

                entity.Property(e => e.AllianceId).HasColumnName("alliance_id");

                entity.Property(e => e.EmpireId).HasColumnName("empire_id");

                entity.Property(e => e.EntryYear).HasColumnName("entry_year");

                entity.HasOne(d => d.Alliance)
                    .WithMany(p => p.AlliancesEntries)
                    .HasForeignKey(d => d.AllianceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alliance_entries_alliances_id_fk");

                entity.HasOne(d => d.Empire)
                    .WithMany(p => p.AlliancesEntries)
                    .HasForeignKey(d => d.EmpireId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alliance_entries_empires_id_fk");
            });

            modelBuilder.Entity<Commander>(entity =>
            {
                entity.ToTable("commanders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.RankId).HasColumnName("rank_id");

                entity.Property(e => e.Skill).HasColumnName("skill");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Commanders)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("commanders_ranks_id_fk");
            });

            modelBuilder.Entity<Empire>(entity =>
            {
                entity.ToTable("empires");

                entity.HasIndex(e => e.Name)
                    .HasName("empires_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GovernmentTypeId).HasColumnName("government_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Ruler)
                    .HasColumnName("ruler")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.GovernmentType)
                    .WithMany(p => p.Empires)
                    .HasForeignKey(d => d.GovernmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empires_government_types_id_fk");
            });

            modelBuilder.Entity<Fleet>(entity =>
            {
                entity.ToTable("fleets");

                entity.HasIndex(e => e.CommanderId)
                    .HasName("fleets_commander_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("fleets_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommanderId).HasColumnName("commander_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Commander)
                    .WithOne(p => p.Fleets)
                    .HasForeignKey<Fleet>(d => d.CommanderId)
                    .HasConstraintName("fleets_commanders_id_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Fleets)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fleets___fk");
            });

            modelBuilder.Entity<GovernmentType>(entity =>
            {
                entity.ToTable("government_types");

                entity.HasIndex(e => e.Name)
                    .HasName("government_types_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.ToTable("planets");

                entity.HasIndex(e => e.Name)
                    .HasName("planets_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approval).HasColumnName("approval");

                entity.Property(e => e.EmpireId).HasColumnName("empire_id");

                entity.Property(e => e.Habitability).HasColumnName("habitability");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Population).HasColumnName("population");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.StarId).HasColumnName("star_id");

                entity.HasOne(d => d.Empire)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.EmpireId)
                    .HasConstraintName("planets_empires_id_fk");

                entity.HasOne(d => d.Star)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.StarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("planets_stars_id_fk");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("ranks");

                entity.HasIndex(e => e.Name)
                    .HasName("ranks_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Shipyard>(entity =>
            {
                entity.ToTable("shipyards");

                entity.HasIndex(e => e.Name)
                    .HasName("shipyards_name_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.PlanetId)
                    .HasName("shipyards_planet_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Pipelines).HasColumnName("pipelines");

                entity.Property(e => e.PlanetId).HasColumnName("planet_id");

                entity.Property(e => e.Staff).HasColumnName("staff");

                entity.HasOne(d => d.Planet)
                    .WithOne(p => p.Shipyards)
                    .HasForeignKey<Shipyard>(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shipyards_planets_id_fk");
            });

            modelBuilder.Entity<Spaceship>(entity =>
            {
                entity.ToTable("spaceships");

                entity.HasIndex(e => e.Name)
                    .HasName("spaceships_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Energy).HasColumnName("energy");

                entity.Property(e => e.Firepower).HasColumnName("firepower");

                entity.Property(e => e.FleetId).HasColumnName("fleet_id");

                entity.Property(e => e.Fuel).HasColumnName("fuel");

                entity.Property(e => e.Hull).HasColumnName("hull");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.ShipyardId).HasColumnName("shipyard_id");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.Staff).HasColumnName("staff");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Fleet)
                    .WithMany(p => p.Spaceships)
                    .HasForeignKey(d => d.FleetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spaceships_fleets_id_fk");

                entity.HasOne(d => d.Shipyard)
                    .WithMany(p => p.Spaceships)
                    .HasForeignKey(d => d.ShipyardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spaceships_shipyards_id_fk");
            });

            modelBuilder.Entity<StarType>(entity =>
            {
                entity.ToTable("star_types");

                entity.HasIndex(e => e.Name)
                    .HasName("star_types_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Star>(entity =>
            {
                entity.ToTable("stars");

                entity.HasIndex(e => e.Name)
                    .HasName("stars_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Stars)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stars_star_types_id_fk");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.ToTable("statuses");

                entity.HasIndex(e => e.Name)
                    .HasName("statuses_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
