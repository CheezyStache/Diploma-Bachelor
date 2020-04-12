using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class ModelUpdateUtilityCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilityCompanyId",
                table: "Utility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UtilityCompany",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityCompany", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utility_UtilityCompanyId",
                table: "Utility",
                column: "UtilityCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilityUtilityCompany",
                table: "Utility",
                column: "UtilityCompanyId",
                principalTable: "UtilityCompany",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilityUtilityCompany",
                table: "Utility");

            migrationBuilder.DropTable(
                name: "UtilityCompany");

            migrationBuilder.DropIndex(
                name: "IX_Utility_UtilityCompanyId",
                table: "Utility");

            migrationBuilder.DropColumn(
                name: "UtilityCompanyId",
                table: "Utility");
        }
    }
}
