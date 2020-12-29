using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreStart.Migrations
{
    public partial class AddTitleFieldToBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BlogPosts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 1,
                columns: new[] { "Post", "Time", "Title" },
                values: new object[] { "My programming post, hi world.", new DateTime(2020, 12, 29, 14, 3, 11, 386, DateTimeKind.Local).AddTicks(8899), "A programming post." });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 2,
                columns: new[] { "Post", "Time", "Title" },
                values: new object[] { "My sports post, hi world.", new DateTime(2020, 12, 29, 14, 3, 11, 390, DateTimeKind.Local).AddTicks(1775), "A sports post." });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 3,
                columns: new[] { "Post", "Time", "Title" },
                values: new object[] { "My music post, hi world.", new DateTime(2020, 12, 29, 14, 3, 11, 390, DateTimeKind.Local).AddTicks(1840), "A music post." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 1,
                columns: new[] { "Post", "Time" },
                values: new object[] { "My programming post.", new DateTime(2020, 12, 29, 13, 14, 41, 651, DateTimeKind.Local).AddTicks(8139) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 2,
                columns: new[] { "Post", "Time" },
                values: new object[] { "My sports post.", new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 3,
                columns: new[] { "Post", "Time" },
                values: new object[] { "My music post.", new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5414) });
        }
    }
}
