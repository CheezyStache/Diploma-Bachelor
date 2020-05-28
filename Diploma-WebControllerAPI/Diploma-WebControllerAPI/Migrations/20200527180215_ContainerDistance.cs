using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class ContainerDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ready",
                table: "Container",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Distance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContainerDistances",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    DistanceID = table.Column<int>(nullable: false),
                    ContainerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerDistances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContainerDistanceContainer",
                        column: x => x.ContainerID,
                        principalTable: "Container",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerDistanceDistance",
                        column: x => x.DistanceID,
                        principalTable: "Distance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDistances_ContainerID",
                table: "ContainerDistances",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDistances_DistanceID",
                table: "ContainerDistances",
                column: "DistanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainerDistances");

            migrationBuilder.DropTable(
                name: "Distance");

            migrationBuilder.DropColumn(
                name: "Ready",
                table: "Container");
        }
    }
}
