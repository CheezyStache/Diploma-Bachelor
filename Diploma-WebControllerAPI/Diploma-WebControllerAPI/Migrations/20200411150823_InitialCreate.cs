using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryDailyStatistics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CitiesCount = table.Column<int>(nullable: false),
                    AvgTime = table.Column<long>(nullable: true),
                    AvgPetrolAmount = table.Column<int>(nullable: true),
                    PetrolAmount = table.Column<int>(nullable: false),
                    AvgDynamicChangesCount = table.Column<int>(nullable: true),
                    DynamicChangesCount = table.Column<int>(nullable: false),
                    AvgContainersCount = table.Column<int>(nullable: true),
                    ContainersCount = table.Column<int>(nullable: false),
                    UtilitiesCount = table.Column<int>(nullable: false),
                    RegionsCount = table.Column<int>(nullable: false),
                    FactoriesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDailyStatistics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UtilityOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    MaxTripsDaily = table.Column<int>(nullable: false),
                    DynamicTrip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyStatistics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AvgTime = table.Column<long>(nullable: true),
                    AvgPetrolAmount = table.Column<int>(nullable: true),
                    PetrolAmount = table.Column<int>(nullable: false),
                    AvgDynamicChangesCount = table.Column<int>(nullable: true),
                    DynamicChangesCount = table.Column<int>(nullable: false),
                    AvgContainersCount = table.Column<int>(nullable: true),
                    ContainersCount = table.Column<int>(nullable: false),
                    UtilitiesCount = table.Column<int>(nullable: false),
                    RegionsCount = table.Column<int>(nullable: false),
                    FactoriesCount = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    CountryStatisticsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStatistics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DailyStatisticsCity",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyStatisticsCountryStatistics",
                        column: x => x.CountryStatisticsID,
                        principalTable: "CountryDailyStatistics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecycleFactory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Ready = table.Column<bool>(nullable: false),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecycleFactory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecycleFactoryLocation",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Ready = table.Column<bool>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    UtilityOptionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utility", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UtilityLocation",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UtilityUtilityOptions",
                        column: x => x.UtilityOptionsID,
                        principalTable: "UtilityOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityUtilities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    UtilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityUtilities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CityUtilitiesCity",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityUtilitiesUtility",
                        column: x => x.UtilityID,
                        principalTable: "Utility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Map = table.Column<int>(nullable: false),
                    UtilityID = table.Column<int>(nullable: false),
                    RecycleFactoryID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegionCity",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionRecycleFactory",
                        column: x => x.RecycleFactoryID,
                        principalTable: "RecycleFactory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionUtility",
                        column: x => x.UtilityID,
                        principalTable: "Utility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Time = table.Column<long>(nullable: true),
                    PetrolAmount = table.Column<int>(nullable: true),
                    DynamicChangesCount = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InProgress = table.Column<bool>(nullable: false),
                    UtilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TripUtility",
                        column: x => x.UtilityID,
                        principalTable: "Utility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Full = table.Column<bool>(nullable: false),
                    LastGather = table.Column<DateTime>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    RegionID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContainerLocation",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerRegion",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegionDailyStatistics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AvgTime = table.Column<long>(nullable: true),
                    AvgPetrolAmount = table.Column<int>(nullable: true),
                    AvgDynamicChangesCount = table.Column<int>(nullable: true),
                    AvgContainersCount = table.Column<int>(nullable: true),
                    UtilityID = table.Column<int>(nullable: false),
                    RegionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionDailyStatistics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegionDailyStatisticsRegion",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionDailyStatisticsUtility",
                        column: x => x.UtilityID,
                        principalTable: "Utility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripContainers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TripID = table.Column<int>(nullable: false),
                    ContainerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripContainers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TripContainersContainer",
                        column: x => x.ContainerID,
                        principalTable: "Container",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripContainersTrip",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityUtilities_CityID",
                table: "CityUtilities",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CityUtilities_UtilityID",
                table: "CityUtilities",
                column: "UtilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Container_LocationID",
                table: "Container",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Container_RegionID",
                table: "Container",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStatistics_CityID",
                table: "DailyStatistics",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStatistics_CountryStatisticsID",
                table: "DailyStatistics",
                column: "CountryStatisticsID");

            migrationBuilder.CreateIndex(
                name: "IX_RecycleFactory_LocationID",
                table: "RecycleFactory",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CityID",
                table: "Region",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_RecycleFactoryID",
                table: "Region",
                column: "RecycleFactoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_UtilityID",
                table: "Region",
                column: "UtilityID");

            migrationBuilder.CreateIndex(
                name: "IX_RegionDailyStatistics_RegionID",
                table: "RegionDailyStatistics",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_RegionDailyStatistics_UtilityID",
                table: "RegionDailyStatistics",
                column: "UtilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_UtilityID",
                table: "Trip",
                column: "UtilityID");

            migrationBuilder.CreateIndex(
                name: "IX_TripContainers_ContainerID",
                table: "TripContainers",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_TripContainers_TripID",
                table: "TripContainers",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_Utility_LocationID",
                table: "Utility",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Utility_UtilityOptionsID",
                table: "Utility",
                column: "UtilityOptionsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityUtilities");

            migrationBuilder.DropTable(
                name: "DailyStatistics");

            migrationBuilder.DropTable(
                name: "RegionDailyStatistics");

            migrationBuilder.DropTable(
                name: "TripContainers");

            migrationBuilder.DropTable(
                name: "CountryDailyStatistics");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "RecycleFactory");

            migrationBuilder.DropTable(
                name: "Utility");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "UtilityOptions");
        }
    }
}
