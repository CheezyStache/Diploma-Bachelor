using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class FinalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityUtilities");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Container",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Container");

            migrationBuilder.CreateTable(
                name: "CityUtilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    UtilityID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CityUtilities_CityID",
                table: "CityUtilities",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CityUtilities_UtilityID",
                table: "CityUtilities",
                column: "UtilityID");
        }
    }
}
