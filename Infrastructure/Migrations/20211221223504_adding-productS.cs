using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addingproductS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId",
                table: "SpecificationAttributeOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId",
                table: "specificationAttributes");

            migrationBuilder.RenameColumn(
                name: "SpecificationAttributeGroupId",
                table: "specificationAttributes",
                newName: "SpecificationAttributeGroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_specificationAttributes_SpecificationAttributeGroupId",
                table: "specificationAttributes",
                newName: "IX_specificationAttributes_SpecificationAttributeGroupId1");

            migrationBuilder.RenameColumn(
                name: "specificationAttributeId",
                table: "SpecificationAttributeOptions",
                newName: "specificationAttributeId1");

            migrationBuilder.RenameIndex(
                name: "IX_SpecificationAttributeOptions_specificationAttributeId",
                table: "SpecificationAttributeOptions",
                newName: "IX_SpecificationAttributeOptions_specificationAttributeId1");

            migrationBuilder.CreateTable(
                name: "ProductSpecificationAttribute",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationAttribute", x => new { x.ProductId, x.SpecificationAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_SpecificationAttributeOptions_SpecificationAttributeOptionId",
                        column: x => x.SpecificationAttributeOptionId,
                        principalTable: "SpecificationAttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationAttribute_SpecificationAttributeOptionId",
                table: "ProductSpecificationAttribute",
                column: "SpecificationAttributeOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId1",
                table: "SpecificationAttributeOptions",
                column: "specificationAttributeId1",
                principalTable: "specificationAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId1",
                table: "specificationAttributes",
                column: "SpecificationAttributeGroupId1",
                principalTable: "specificationAttributeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId1",
                table: "SpecificationAttributeOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId1",
                table: "specificationAttributes");

            migrationBuilder.DropTable(
                name: "ProductSpecificationAttribute");

            migrationBuilder.RenameColumn(
                name: "SpecificationAttributeGroupId1",
                table: "specificationAttributes",
                newName: "SpecificationAttributeGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_specificationAttributes_SpecificationAttributeGroupId1",
                table: "specificationAttributes",
                newName: "IX_specificationAttributes_SpecificationAttributeGroupId");

            migrationBuilder.RenameColumn(
                name: "specificationAttributeId1",
                table: "SpecificationAttributeOptions",
                newName: "specificationAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecificationAttributeOptions_specificationAttributeId1",
                table: "SpecificationAttributeOptions",
                newName: "IX_SpecificationAttributeOptions_specificationAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId",
                table: "SpecificationAttributeOptions",
                column: "specificationAttributeId",
                principalTable: "specificationAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId",
                table: "specificationAttributes",
                column: "SpecificationAttributeGroupId",
                principalTable: "specificationAttributeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
