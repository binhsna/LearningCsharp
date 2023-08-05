using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationExample.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    TagId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "articletag",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articletag", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_articletag_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articletag_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articletag_ArticleId",
                table: "articletag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_articletag_ArticleTagId_TagId",
                table: "articletag",
                columns: new[] { "ArticleTagId", "TagId" },
                unique: true,
                filter: "[TagId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_articletag_TagId",
                table: "articletag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articletag");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
