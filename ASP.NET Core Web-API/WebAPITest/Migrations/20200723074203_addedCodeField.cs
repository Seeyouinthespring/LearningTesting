using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPITest.Migrations
{
    public partial class addedCodeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_countryId",
                table: "Cities",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
