using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
