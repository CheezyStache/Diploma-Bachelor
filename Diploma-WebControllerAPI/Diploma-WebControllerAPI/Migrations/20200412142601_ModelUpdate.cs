using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Utility",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectedContainersCount",
                table: "RegionDailyStatistics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContainersCount",
                table: "RegionDailyStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DynamicChangesCount",
                table: "RegionDailyStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetrolAmount",
                table: "RegionDailyStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Region",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Population",
                table: "Region",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RecycleFactory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectedContainersCount",
                table: "DailyStatistics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectedContainersCount",
                table: "CountryDailyStatistics",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Population",
                table: "City",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Utility");

            migrationBuilder.DropColumn(
                name: "CollectedContainersCount",
                table: "RegionDailyStatistics");

            migrationBuilder.DropColumn(
                name: "ContainersCount",
                table: "RegionDailyStatistics");

            migrationBuilder.DropColumn(
                name: "DynamicChangesCount",
                table: "RegionDailyStatistics");

            migrationBuilder.DropColumn(
                name: "PetrolAmount",
                table: "RegionDailyStatistics");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RecycleFactory");

            migrationBuilder.DropColumn(
                name: "CollectedContainersCount",
                table: "DailyStatistics");

            migrationBuilder.DropColumn(
                name: "CollectedContainersCount",
                table: "CountryDailyStatistics");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "City");
        }
    }
}
