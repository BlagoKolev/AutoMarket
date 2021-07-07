using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_PartOffers_PartOfferId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePicture_VehicleOffers_VehicleOfferId",
                table: "VehiclePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclePicture",
                table: "VehiclePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "VehiclePicture",
                newName: "VehiclePictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "PartPictures");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclePicture_VehicleOfferId",
                table: "VehiclePictures",
                newName: "IX_VehiclePictures_VehicleOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_PartOfferId",
                table: "PartPictures",
                newName: "IX_PartPictures_PartOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclePictures",
                table: "VehiclePictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartPictures",
                table: "PartPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartPictures_PartOffers_PartOfferId",
                table: "PartPictures",
                column: "PartOfferId",
                principalTable: "PartOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePictures_VehicleOffers_VehicleOfferId",
                table: "VehiclePictures",
                column: "VehicleOfferId",
                principalTable: "VehicleOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartPictures_PartOffers_PartOfferId",
                table: "PartPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePictures_VehicleOffers_VehicleOfferId",
                table: "VehiclePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclePictures",
                table: "VehiclePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartPictures",
                table: "PartPictures");

            migrationBuilder.RenameTable(
                name: "VehiclePictures",
                newName: "VehiclePicture");

            migrationBuilder.RenameTable(
                name: "PartPictures",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclePictures_VehicleOfferId",
                table: "VehiclePicture",
                newName: "IX_VehiclePicture_VehicleOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_PartPictures_PartOfferId",
                table: "Pictures",
                newName: "IX_Pictures_PartOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclePicture",
                table: "VehiclePicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_PartOffers_PartOfferId",
                table: "Pictures",
                column: "PartOfferId",
                principalTable: "PartOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePicture_VehicleOffers_VehicleOfferId",
                table: "VehiclePicture",
                column: "VehicleOfferId",
                principalTable: "VehicleOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
