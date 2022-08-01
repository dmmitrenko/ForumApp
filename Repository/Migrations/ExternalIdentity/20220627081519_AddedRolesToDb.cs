using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Repository.Migrations.ExternalIdentity
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95306004-0760-46c6-a78e-ddb731b699d3", "8a77cb2b-74e6-49d4-8ef2-88e2d34d6ace", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d12c2442-7926-43d9-ad9e-bfb9608bbdb3", "965fe947-1193-4a85-b320-70303bebf00b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95306004-0760-46c6-a78e-ddb731b699d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d12c2442-7926-43d9-ad9e-bfb9608bbdb3");
        }
    }
}
