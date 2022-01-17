using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    public partial class addtouristmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Nationalities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TourDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTour",
                columns: table => new
                {
                    PlacesPlaceId = table.Column<int>(type: "int", nullable: false),
                    ToursTourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTour", x => new { x.PlacesPlaceId, x.ToursTourId });
                    table.ForeignKey(
                        name: "FK_PlaceTour_Places_PlacesPlaceId",
                        column: x => x.PlacesPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceTour_Tours_ToursTourId",
                        column: x => x.ToursTourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourTourist",
                columns: table => new
                {
                    TouristsTouristId = table.Column<int>(type: "int", nullable: false),
                    ToursTourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTourist", x => new { x.TouristsTouristId, x.ToursTourId });
                    table.ForeignKey(
                        name: "FK_TourTourist_Tourists_TouristsTouristId",
                        column: x => x.TouristsTouristId,
                        principalTable: "Tourists",
                        principalColumn: "TouristId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourTourist_Tours_ToursTourId",
                        column: x => x.ToursTourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tourists_CountryId",
                table: "Tourists",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourists_NationalityId",
                table: "Tourists",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTour_ToursTourId",
                table: "PlaceTour",
                column: "ToursTourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourTourist_ToursTourId",
                table: "TourTourist",
                column: "ToursTourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_Countries_CountryId",
                table: "Tourists",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_Nationalities_NationalityId",
                table: "Tourists",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_Countries_CountryId",
                table: "Tourists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_Nationalities_NationalityId",
                table: "Tourists");

            migrationBuilder.DropTable(
                name: "PlaceTour");

            migrationBuilder.DropTable(
                name: "TourTourist");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tourists_CountryId",
                table: "Tourists");

            migrationBuilder.DropIndex(
                name: "IX_Tourists_NationalityId",
                table: "Tourists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");
        }
    }
}
