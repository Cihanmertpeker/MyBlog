using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogCategories_Blogs_BlogId",
                table: "blogCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_blogCategories_Categories_CategoryId",
                table: "blogCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogCategories",
                table: "blogCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "blogCategories",
                newName: "BlogCategories");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Blogs",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_blogCategories_CategoryId",
                table: "BlogCategories",
                newName: "IX_BlogCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_blogCategories_BlogId",
                table: "BlogCategories",
                newName: "IX_BlogCategories_BlogId");

            migrationBuilder.AddColumn<string>(
                name: "Definition",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoUrl",
                table: "Categories",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoUrl",
                table: "Blogs",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SeoUrl",
                table: "Categories",
                column: "SeoUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_SeoUrl",
                table: "Blogs",
                column: "SeoUrl",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_Blogs_BlogId",
                table: "BlogCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_Categories_CategoryId",
                table: "BlogCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_Blogs_BlogId",
                table: "BlogCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_Categories_CategoryId",
                table: "BlogCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SeoUrl",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_SeoUrl",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogCategories",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "Definition",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SeoUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "SeoUrl",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogCategories",
                newName: "blogCategories");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Blogs",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_BlogCategories_CategoryId",
                table: "blogCategories",
                newName: "IX_blogCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogCategories_BlogId",
                table: "blogCategories",
                newName: "IX_blogCategories_BlogId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogCategories",
                table: "blogCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogCategories_Blogs_BlogId",
                table: "blogCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogCategories_Categories_CategoryId",
                table: "blogCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
