using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3305), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3346), "Bye world!", "About me", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3366), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3369), "Hello world!", "About me", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BlogId", "DateAdded", "LastChange", "Text", "UserId" },
                values: new object[] { new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"), new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3721), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3724), "Not good!", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BlogId", "DateAdded", "LastChange", "Text", "UserId" },
                values: new object[] { new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"), new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3705), new DateTime(2022, 6, 27, 10, 34, 50, 861, DateTimeKind.Local).AddTicks(3712), "Good!", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
