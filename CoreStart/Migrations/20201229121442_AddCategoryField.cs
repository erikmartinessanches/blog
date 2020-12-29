using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreStart.Migrations
{
    public partial class AddCategoryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "BlogPosts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "P", "Programming" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "S", "Sport" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "M", "Music" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "Author", "CategoryId", "Post", "Time" },
                values: new object[] { 1, "Erik Martines Sanches", "P", "My programming post.", new DateTime(2020, 12, 29, 13, 14, 41, 651, DateTimeKind.Local).AddTicks(8139) });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "Author", "CategoryId", "Post", "Time" },
                values: new object[] { 2, "Erik Martines Sanches", "S", "My sports post.", new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "Author", "CategoryId", "Post", "Time" },
                values: new object[] { 3, "Erik Martines Sanches", "M", "My music post.", new DateTime(2020, 12, 29, 13, 14, 41, 655, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BlogPosts");
        }
    }
}
