﻿// <auto-generated />
using System;
using ForumApp.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Repository.Migrations.Repository
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220627163426_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApp.Entities.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CommentId");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe5d3bc3-cc2e-4060-8dae-fb010dcdd0be"),
                            DateAdded = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1514),
                            LastChange = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1518),
                            PostId = new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                            Text = "Good!",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("9b5d639c-200a-49f7-b944-c278bfc33a5a"),
                            DateAdded = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1525),
                            LastChange = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1533),
                            PostId = new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                            Text = "Not good!",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("ForumApp.Entities.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PostId");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2409f6fa-464d-4db7-ba7f-3129b62ab0e1"),
                            DateAdded = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1238),
                            LastChange = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1289),
                            Text = "Bye world!",
                            Title = "About me",
                            UserId = new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12")
                        },
                        new
                        {
                            Id = new Guid("9fbf9c03-1e67-4cda-89ed-bf3a7a5da11a"),
                            DateAdded = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1312),
                            LastChange = new DateTime(2022, 6, 27, 19, 34, 26, 46, DateTimeKind.Local).AddTicks(1314),
                            Text = "Hello world!",
                            Title = "About me",
                            UserId = new Guid("5bd958d5-feb1-4860-aedc-ec40047abc12")
                        });
                });

            modelBuilder.Entity("ForumApp.Entities.Models.Comment", b =>
                {
                    b.HasOne("ForumApp.Entities.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ForumApp.Entities.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
