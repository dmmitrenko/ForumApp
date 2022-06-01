using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AddCommentsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChange",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                columns: new[] { "LastChange", "Text" },
                values: new object[] { new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7184), "Bye world!" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                column: "LastChange",
                value: new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BlogId", "LastChange", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"), new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7337), "Not good!", new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d") },
                    { new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"), new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 1, 10, 57, 53, 279, DateTimeKind.Local).AddTicks(7326), "Good!", new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"),
                column: "Email",
                value: "dmmytrenko@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"),
                columns: new[] { "Email", "Role" },
                values: new object[] { "fil@gmail.com", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastChange",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                column: "Text",
                value: "I am a student");
        }
    }
}
