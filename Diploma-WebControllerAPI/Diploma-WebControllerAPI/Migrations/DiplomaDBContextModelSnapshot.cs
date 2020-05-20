﻿// <auto-generated />
using System;
using Diploma_WebControllerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma_WebControllerAPI.Migrations
{
    [DbContext(typeof(DiplomaDBContext))]
    partial class DiplomaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Full")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastGather")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RegionId");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.CountryDailyStatistics", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int?>("AvgContainersCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgDynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgPetrolAmount")
                        .HasColumnType("int");

                    b.Property<long?>("AvgTime")
                        .HasColumnType("bigint");

                    b.Property<int>("CitiesCount")
                        .HasColumnType("int");

                    b.Property<int?>("CollectedContainersCount")
                        .HasColumnType("int");

                    b.Property<int>("ContainersCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int>("FactoriesCount")
                        .HasColumnType("int");

                    b.Property<int>("PetrolAmount")
                        .HasColumnType("int");

                    b.Property<int>("RegionsCount")
                        .HasColumnType("int");

                    b.Property<int>("UtilitiesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountryDailyStatistics");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.DailyStatistics", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int?>("AvgContainersCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgDynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgPetrolAmount")
                        .HasColumnType("int");

                    b.Property<long?>("AvgTime")
                        .HasColumnType("bigint");

                    b.Property<int>("CityId")
                        .HasColumnName("CityID")
                        .HasColumnType("int");

                    b.Property<int?>("CollectedContainersCount")
                        .HasColumnType("int");

                    b.Property<int>("ContainersCount")
                        .HasColumnType("int");

                    b.Property<int?>("CountryStatisticsId")
                        .HasColumnName("CountryStatisticsID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int>("FactoriesCount")
                        .HasColumnType("int");

                    b.Property<int>("PetrolAmount")
                        .HasColumnType("int");

                    b.Property<int>("RegionsCount")
                        .HasColumnType("int");

                    b.Property<int>("UtilitiesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryStatisticsId");

                    b.ToTable("DailyStatistics");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.RecycleFactory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("Ready")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("RecycleFactory");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnName("CityID")
                        .HasColumnType("int");

                    b.Property<int>("Map")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<int>("RecycleFactoryId")
                        .HasColumnName("RecycleFactoryID")
                        .HasColumnType("int");

                    b.Property<int>("UtilityId")
                        .HasColumnName("UtilityID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("RecycleFactoryId");

                    b.HasIndex("UtilityId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.RegionDailyStatistics", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int?>("AvgContainersCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgDynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int?>("AvgPetrolAmount")
                        .HasColumnType("int");

                    b.Property<long?>("AvgTime")
                        .HasColumnType("bigint");

                    b.Property<int?>("CollectedContainersCount")
                        .HasColumnType("int");

                    b.Property<int>("ContainersCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<int>("PetrolAmount")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.Property<int>("UtilityId")
                        .HasColumnName("UtilityID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("UtilityId");

                    b.ToTable("RegionDailyStatistics");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DynamicChangesCount")
                        .HasColumnType("int");

                    b.Property<bool>("InProgress")
                        .HasColumnType("bit");

                    b.Property<int?>("PetrolAmount")
                        .HasColumnType("int");

                    b.Property<long?>("Time")
                        .HasColumnType("bigint");

                    b.Property<int>("UtilityId")
                        .HasColumnName("UtilityID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilityId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.TripContainers", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("ContainerId")
                        .HasColumnName("ContainerID")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnName("TripID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.HasIndex("TripId");

                    b.ToTable("TripContainers");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Utility", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("Ready")
                        .HasColumnType("bit");

                    b.Property<int>("UtilityCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("UtilityOptionsId")
                        .HasColumnName("UtilityOptionsID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("UtilityCompanyId");

                    b.HasIndex("UtilityOptionsId");

                    b.ToTable("Utility");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.UtilityCompany", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("UtilityCompany");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.UtilityOptions", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("int");

                    b.Property<bool>("DynamicTrip")
                        .HasColumnType("bit");

                    b.Property<int>("MaxTripsDaily")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UtilityOptions");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Container", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Location", "Location")
                        .WithMany("Container")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_ContainerLocation")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.Region", "Region")
                        .WithMany("Container")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_ContainerRegion")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.DailyStatistics", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.City", "City")
                        .WithMany("DailyStatistics")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_DailyStatisticsCity")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.CountryDailyStatistics", "CountryStatistics")
                        .WithMany("DailyStatistics")
                        .HasForeignKey("CountryStatisticsId")
                        .HasConstraintName("FK_DailyStatisticsCountryStatistics");
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.RecycleFactory", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Location", "Location")
                        .WithMany("RecycleFactory")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_RecycleFactoryLocation")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Region", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.City", "City")
                        .WithMany("Region")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_RegionCity")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.RecycleFactory", "RecycleFactory")
                        .WithMany("Region")
                        .HasForeignKey("RecycleFactoryId")
                        .HasConstraintName("FK_RegionRecycleFactory")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.Utility", "Utility")
                        .WithMany("Region")
                        .HasForeignKey("UtilityId")
                        .HasConstraintName("FK_RegionUtility")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.RegionDailyStatistics", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Region", "Region")
                        .WithMany("RegionDailyStatistics")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_RegionDailyStatisticsRegion")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.Utility", "Utility")
                        .WithMany("RegionDailyStatistics")
                        .HasForeignKey("UtilityId")
                        .HasConstraintName("FK_RegionDailyStatisticsUtility")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Trip", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Utility", "Utility")
                        .WithMany("Trip")
                        .HasForeignKey("UtilityId")
                        .HasConstraintName("FK_TripUtility")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.TripContainers", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Container", "Container")
                        .WithMany("TripContainers")
                        .HasForeignKey("ContainerId")
                        .HasConstraintName("FK_TripContainersContainer")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.Trip", "Trip")
                        .WithMany("TripContainers")
                        .HasForeignKey("TripId")
                        .HasConstraintName("FK_TripContainersTrip")
                        .IsRequired();
                });

            modelBuilder.Entity("Diploma_WebControllerAPI.Models.Utility", b =>
                {
                    b.HasOne("Diploma_WebControllerAPI.Models.Location", "Location")
                        .WithMany("Utility")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_UtilityLocation")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.UtilityCompany", "UtilityCompany")
                        .WithMany("Utility")
                        .HasForeignKey("UtilityCompanyId")
                        .HasConstraintName("FK_UtilityUtilityCompany")
                        .IsRequired();

                    b.HasOne("Diploma_WebControllerAPI.Models.UtilityOptions", "UtilityOptions")
                        .WithMany("Utility")
                        .HasForeignKey("UtilityOptionsId")
                        .HasConstraintName("FK_UtilityUtilityOptions")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
