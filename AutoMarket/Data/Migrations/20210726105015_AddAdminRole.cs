using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1da01636-8fd2-4be9-b924-b4803ed1b363", "837f26b1-dbf3-4de0-93f7-62751e69fe6f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da01636-8fd2-4be9-b924-b4803ed1b363");
        }
    }
}
