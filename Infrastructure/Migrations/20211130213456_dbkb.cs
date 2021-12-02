using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dbkb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pictures_Categories_CategoryId",
                table: "pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_pictures_products_ProductId",
                table: "pictures");

            migrationBuilder.DropIndex(
                name: "IX_pictures_CategoryId",
                table: "pictures");

            migrationBuilder.DropIndex(
                name: "IX_pictures_ProductId",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "categoryPictures");

            migrationBuilder.CreateTable(
                name: "CategoryPicture",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    picturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPicture", x => new { x.CategoriesId, x.picturesId });
                    table.ForeignKey(
                        name: "FK_CategoryPicture_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPicture_pictures_picturesId",
                        column: x => x.picturesId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PictureProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    picturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureProduct", x => new { x.ProductsId, x.picturesId });
                    table.ForeignKey(
                        name: "FK_PictureProduct_pictures_picturesId",
                        column: x => x.picturesId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureProduct_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPicture_picturesId",
                table: "CategoryPicture",
                column: "picturesId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureProduct_picturesId",
                table: "PictureProduct",
                column: "picturesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPicture");

            migrationBuilder.DropTable(
                name: "PictureProduct");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "pictures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "pictures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "categoryPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pictures_CategoryId",
                table: "pictures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_pictures_ProductId",
                table: "pictures",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_pictures_Categories_CategoryId",
                table: "pictures",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pictures_products_ProductId",
                table: "pictures",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
