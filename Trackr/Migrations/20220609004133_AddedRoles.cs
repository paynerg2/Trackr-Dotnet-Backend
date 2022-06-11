using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackr.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d1c356b-4eed-4a4c-b4c1-61a1eb117bdf", "e861cd60-5176-4a5d-b5c9-4e80dde65e99", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d1c356b-4eed-4a4c-b4c1-61a1eb117bdf");
        }
    }
}
