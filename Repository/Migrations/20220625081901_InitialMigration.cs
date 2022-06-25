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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

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
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateRegistration", "Email", "Name", "Nickname", "Role", "Surname" },
                values: new object[] { new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(8101), "dmmytrenko@gmail.com", "Serhii", "dmytrenko", 0, "Dmytrenko" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateRegistration", "Email", "Name", "Nickname", "Role", "Surname" },
                values: new object[] { new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(8049), "fil@gmail.com", "Kateryna", "filinskaya", 1, "Filinska" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9617), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9631), "Bye world!", "About me", new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d") });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9641), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9644), "Hello world!", "About me", new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BlogId", "DateAdded", "LastChange", "Text", "UserId" },
                values: new object[] { new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"), new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9792), "Not good!", new Guid("11b3a2fc-8d75-45de-9990-00d5d5159c2d") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "BlogId", "DateAdded", "LastChange", "Text", "UserId" },
                values: new object[] { new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"), new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9777), new DateTime(2022, 6, 25, 11, 19, 1, 191, DateTimeKind.Local).AddTicks(9781), "Good!", new Guid("f5f9c508-5b57-4e17-bb05-5da2183e931e") });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
