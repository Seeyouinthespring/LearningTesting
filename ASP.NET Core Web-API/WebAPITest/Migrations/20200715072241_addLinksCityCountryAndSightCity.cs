using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPITest.Migrations
{
    public partial class addLinksCityCountryAndSightCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "Sightseens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sightseens_cityId",
                table: "Sightseens",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_countryId",
                table: "Cities",
                column: "countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sightseens_Cities_cityId",
                table: "Sightseens",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sightseens_Cities_cityId",
                table: "Sightseens");

            migrationBuilder.DropIndex(
                name: "IX_Sightseens_cityId",
                table: "Sightseens");

            migrationBuilder.DropIndex(
                name: "IX_Cities_countryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "Sightseens");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "Cities");
        }
    }
}
