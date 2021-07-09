using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Data.Migrations
{
    public partial class CreateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartPictures");

            migrationBuilder.DropTable(
                name: "VehiclePictures");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartOfferId = table.Column<int>(type: "int", nullable: true),
                    VehicleOfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_PartOffers_PartOfferId",
                        column: x => x.PartOfferId,
                        principalTable: "PartOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_VehicleOffers_VehicleOfferId",
                        column: x => x.VehicleOfferId,
                        principalTable: "VehicleOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PartOfferId",
                table: "Images",
                column: "PartOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_VehicleOfferId",
                table: "Images",
                column: "VehicleOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.CreateTable(
                name: "PartPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartOfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartPictures_PartOffers_PartOfferId",
                        column: x => x.PartOfferId,
                        principalTable: "PartOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleOfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePictures_VehicleOffers_VehicleOfferId",
                        column: x => x.VehicleOfferId,
                        principalTable: "VehicleOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartPictures_PartOfferId",
                table: "PartPictures",
                column: "PartOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePictures_VehicleOfferId",
                table: "VehiclePictures",
                column: "VehicleOfferId");
        }
    }
}
