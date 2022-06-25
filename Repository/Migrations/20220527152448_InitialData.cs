using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Blogs");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Nickname", "Surname" },
                values: new object[] { new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"), "Serhii", "dmytrenko", "Dmytrenko" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Nickname", "Surname" },
                values: new object[] { new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"), "Kateryna", "filinskaya", "Filinska" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Text", "Title", "UserId" },
                values: new object[] { new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), "I am a student", "About me", new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d") });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Text", "Title", "UserId" },
                values: new object[] { new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), "Hello world!", "About me", new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
