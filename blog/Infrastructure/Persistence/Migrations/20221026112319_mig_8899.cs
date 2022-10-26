using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_8899 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleCodeId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ArticleCodeId",
                table: "Comments",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleCodeId",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Comments",
                newName: "ArticleCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                newName: "IX_Comments_ArticleCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleCodeId",
                table: "Comments",
                column: "ArticleCodeId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
