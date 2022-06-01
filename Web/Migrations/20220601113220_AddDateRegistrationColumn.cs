using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AddDateRegistrationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistration",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                columns: new[] { "DateAdded", "LastChange" },
                values: new object[] { new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(3881), new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                columns: new[] { "DateAdded", "LastChange" },
                values: new object[] { new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(3905), new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(3907) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"),
                columns: new[] { "DateAdded", "LastChange" },
                values: new object[] { new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(4063), new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"),
                columns: new[] { "DateAdded", "LastChange" },
                values: new object[] { new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(4051), new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"),
                column: "DateRegistration",
                value: new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"),
                column: "DateRegistration",
                value: new DateTime(2022, 6, 1, 14, 32, 19, 970, DateTimeKind.Local).AddTicks(2429));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                column: "LastChange",
                value: new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                column: "LastChange",
                value: new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"),
                column: "LastChange",
                value: new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"),
                column: "LastChange",
                value: new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7326));
        }
    }
}
