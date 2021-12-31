using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class proatt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specificationAttributeGroups_Categories_CategoryId",
                table: "specificationAttributeGroups");

            migrationBuilder.DropIndex(
                name: "IX_specificationAttributeGroups_CategoryId",
                table: "specificationAttributeGroups");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "specificationAttributeGroups");

            migrationBuilder.CreateTable(
                name: "productAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productAttributeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productAttributeOptions_productAttributes_productAttributeId",
                        column: x => x.productAttributeId,
                        principalTable: "productAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productAttributeMappings",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAttributeOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributeMappings", x => new { x.ProductId, x.ProductAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_productAttributeMappings_productAttributeOptions_ProductAttributeOptionId",
                        column: x => x.ProductAttributeOptionId,
                        principalTable: "productAttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productAttributeMappings_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productAttributeMappings_ProductAttributeOptionId",
                table: "productAttributeMappings",
                column: "ProductAttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_productAttributeOptions_productAttributeId",
                table: "productAttributeOptions",
                column: "productAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productAttributeMappings");

            migrationBuilder.DropTable(
                name: "productAttributeOptions");

            migrationBuilder.DropTable(
                name: "productAttributes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "specificationAttributeGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_specificationAttributeGroups_CategoryId",
                table: "specificationAttributeGroups",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_specificationAttributeGroups_Categories_CategoryId",
                table: "specificationAttributeGroups",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
