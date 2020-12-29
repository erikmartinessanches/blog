﻿// <auto-generated />
using System;
using CoreStart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreStart.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20201229121442_AddCategoryField")]
    partial class AddCategoryField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreStart.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Time")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("BlogPostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            BlogPostId = 1,
                            Author = "Erik Martines Sanches",
                            CategoryId = "P",
                            Post = "My programming post.",
                            Time = new DateTime(2020, 12, 29, 13, 14, 41, 651, DateTimeKind.Local).AddTicks(8139)
                        },
                        new
                        {
                            BlogPostId = 2,
                            Author = "Erik Martines Sanches",
                            CategoryId = "S",
                            Post = "My sports post.",
                            Time = new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5349)
                        },
                        new
                        {
                            BlogPostId = 3,
                            Author = "Erik Martines Sanches",
                            CategoryId = "M",
                            Post = "My music post.",
                            Time = new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5414)
                        });
                });

            modelBuilder.Entity("CoreStart.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "P",
                            Name = "Programming"
                        },
                        new
                        {
                            CategoryId = "S",
                            Name = "Sport"
                        },
                        new
                        {
                            CategoryId = "M",
                            Name = "Music"
                        });
                });

            modelBuilder.Entity("CoreStart.Models.BlogPost", b =>
                {
                    b.HasOne("CoreStart.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}