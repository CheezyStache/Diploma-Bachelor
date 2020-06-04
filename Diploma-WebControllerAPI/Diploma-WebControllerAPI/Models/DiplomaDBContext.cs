using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diploma_WebControllerAPI.Models
{
    public partial class DiplomaDBContext : DbContext
    {
        public DiplomaDBContext()
        {
        }

        public DiplomaDBContext(DbContextOptions<DiplomaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<ContainerDistance> ContainerDistances { get; set; }
        public virtual DbSet<CountryDailyStatistics> CountryDailyStatistics { get; set; }
        public virtual DbSet<DailyStatistics> DailyStatistics { get; set; }
        public virtual DbSet<Distance> Distance { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<RecycleFactory> RecycleFactory { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionDailyStatistics> RegionDailyStatistics { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<TripContainers> TripContainers { get; set; }
        public virtual DbSet<Utility> Utility { get; set; }
        public virtual DbSet<UtilityOptions> UtilityOptions { get; set; }
        public virtual DbSet<UtilityCompany> UtilityCompany { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:cutpaks-diploma.database.windows.net,1433;Initial Catalog=DiplomaDB;Persist Security Info=False;User ID=cutpaks;Password=Mustache_man;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Container)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContainerLocation");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Container)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContainerRegion");
            });

            modelBuilder.Entity<ContainerDistance>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

                entity.Property(e => e.DistanceId).HasColumnName("DistanceID");

                entity.HasOne(d => d.Container)
                    .WithMany(p => p.ContainerDistances)
                    .HasForeignKey(d => d.ContainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContainerDistanceContainer");

                entity.HasOne(d => d.Distance)
                    .WithMany(p => p.ContainerDistances)
                    .HasForeignKey(d => d.DistanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContainerDistanceDistance");
            });

            modelBuilder.Entity<CountryDailyStatistics>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<DailyStatistics>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryStatisticsId).HasColumnName("CountryStatisticsID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.DailyStatistics)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyStatisticsCity");

                entity.HasOne(d => d.CountryStatistics)
                    .WithMany(p => p.DailyStatistics)
                    .HasForeignKey(d => d.CountryStatisticsId)
                    .HasConstraintName("FK_DailyStatisticsCountryStatistics");
            });

            modelBuilder.Entity<Distance>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<RecycleFactory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.RecycleFactory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecycleFactoryLocation");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Map)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.RecycleFactoryId).HasColumnName("RecycleFactoryID");

                entity.Property(e => e.UtilityId).HasColumnName("UtilityID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionCity");

                entity.HasOne(d => d.RecycleFactory)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.RecycleFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionRecycleFactory");

                entity.HasOne(d => d.Utility)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.UtilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionUtility");
            });

            modelBuilder.Entity<RegionDailyStatistics>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.UtilityId).HasColumnName("UtilityID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RegionDailyStatistics)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionDailyStatisticsRegion");

                entity.HasOne(d => d.Utility)
                    .WithMany(p => p.RegionDailyStatistics)
                    .HasForeignKey(d => d.UtilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionDailyStatisticsUtility");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UtilityId).HasColumnName("UtilityID");

                entity.HasOne(d => d.Utility)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.UtilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripUtility");
            });

            modelBuilder.Entity<TripContainers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.Container)
                    .WithMany(p => p.TripContainers)
                    .HasForeignKey(d => d.ContainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripContainersContainer");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripContainers)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripContainersTrip");
            });

            modelBuilder.Entity<Utility>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.UtilityOptionsId).HasColumnName("UtilityOptionsID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Utility)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UtilityLocation");

                entity.HasOne(d => d.UtilityOptions)
                    .WithMany(p => p.Utility)
                    .HasForeignKey(d => d.UtilityOptionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UtilityUtilityOptions");

                entity.HasOne(d => d.UtilityCompany)
                    .WithMany(p => p.Utility)
                    .HasForeignKey(d => d.UtilityCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UtilityUtilityCompany");
            });

            modelBuilder.Entity<UtilityOptions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<UtilityCompany>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
