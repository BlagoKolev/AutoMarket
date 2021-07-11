using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Migrations
{
    public partial class ChangeUserIDTypeInOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOffers_AspNetUsers_ApplicationUserId1",
                table: "PartOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOffers_AspNetUsers_ApplicationUserId1",
                table: "VehicleOffers");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOffers_ApplicationUserId1",
                table: "VehicleOffers");

            migrationBuilder.DropIndex(
                name: "IX_PartOffers_ApplicationUserId1",
                table: "PartOffers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "VehicleOffers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PartOffers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "VehicleOffers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PartOffers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOffers_ApplicationUserId",
                table: "VehicleOffers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOffers_ApplicationUserId",
                table: "PartOffers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOffers_AspNetUsers_ApplicationUserId",
                table: "PartOffers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOffers_AspNetUsers_ApplicationUserId",
                table: "VehicleOffers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOffers_AspNetUsers_ApplicationUserId",
                table: "PartOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOffers_AspNetUsers_ApplicationUserId",
                table: "VehicleOffers");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOffers_ApplicationUserId",
                table: "VehicleOffers");

            migrationBuilder.DropIndex(
                name: "IX_PartOffers_ApplicationUserId",
                table: "PartOffers");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "VehicleOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "VehicleOffers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "PartOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PartOffers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOffers_ApplicationUserId1",
                table: "VehicleOffers",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PartOffers_ApplicationUserId1",
                table: "PartOffers",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOffers_AspNetUsers_ApplicationUserId1",
                table: "PartOffers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOffers_AspNetUsers_ApplicationUserId1",
                table: "VehicleOffers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
