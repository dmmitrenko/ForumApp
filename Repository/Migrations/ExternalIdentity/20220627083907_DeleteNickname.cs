using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Repository.Migrations.ExternalIdentity
{
    public partial class DeleteNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95306004-0760-46c6-a78e-ddb731b699d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d12c2442-7926-43d9-ad9e-bfb9608bbdb3");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "532a8334-186e-4ebf-8917-31dd17c7b9bd", "4e53bbc3-da56-4653-b0a2-c240e9221b9e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "826d6ff2-d782-461b-8719-8ea8ec4d0c49", "0daaabbb-79b7-4c77-b6ad-6f3ca99121cc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532a8334-186e-4ebf-8917-31dd17c7b9bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "826d6ff2-d782-461b-8719-8ea8ec4d0c49");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95306004-0760-46c6-a78e-ddb731b699d3", "8a77cb2b-74e6-49d4-8ef2-88e2d34d6ace", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d12c2442-7926-43d9-ad9e-bfb9608bbdb3", "965fe947-1193-4a85-b320-70303bebf00b", "Admin", "ADMIN" });
        }
    }
}
