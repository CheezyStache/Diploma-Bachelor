using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma_WebControllerAPI.Migrations
{
    public partial class TspUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecycleFactoryId",
                table: "ContainerDistances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilityId",
                table: "ContainerDistances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDistances_RecycleFactoryId",
                table: "ContainerDistances",
                column: "RecycleFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDistances_UtilityId",
                table: "ContainerDistances",
                column: "UtilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDistanceFactory",
                table: "ContainerDistances",
                column: "RecycleFactoryId",
                principalTable: "RecycleFactory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDistanceUtility",
                table: "ContainerDistances",
                column: "UtilityId",
                principalTable: "Utility",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDistanceFactory",
                table: "ContainerDistances");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDistanceUtility",
                table: "ContainerDistances");

            migrationBuilder.DropIndex(
                name: "IX_ContainerDistances_RecycleFactoryId",
                table: "ContainerDistances");

            migrationBuilder.DropIndex(
                name: "IX_ContainerDistances_UtilityId",
                table: "ContainerDistances");

            migrationBuilder.DropColumn(
                name: "RecycleFactoryId",
                table: "ContainerDistances");

            migrationBuilder.DropColumn(
                name: "UtilityId",
                table: "ContainerDistances");
        }
    }
}
