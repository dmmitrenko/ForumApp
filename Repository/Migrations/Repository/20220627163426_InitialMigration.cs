using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Repository.Migrations.Repository
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_PostId",
                        column: x => x.PostId,
                        principalTable: "Blogs",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "PostId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1238), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1289), "Bye world!", "About me", new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12") });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "PostId", "DateAdded", "LastChange", "Text", "Title", "UserId" },
                values: new object[] { new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1312), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1314), "Hello world!", "About me", new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "DateAdded", "LastChange", "PostId", "Text", "UserId" },
                values: new object[] { new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1525), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1533), new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"), "Not good!", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "DateAdded", "LastChange", "PostId", "Text", "UserId" },
                values: new object[] { new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1514), new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1518), new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"), "Good!", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
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
