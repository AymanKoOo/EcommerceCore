using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class categ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "specificationAttributeGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categorySpecificationGroups",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorySpecificationGroups", x => new { x.CategoryId, x.SpecificationAttributeGroupId });
                    table.ForeignKey(
                        name: "FK_categorySpecificationGroups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorySpecificationGroups_specificationAttributeGroups_SpecificationAttributeGroupId",
                        column: x => x.SpecificationAttributeGroupId,
                        principalTable: "specificationAttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_specificationAttributeGroups_CategoryId",
                table: "specificationAttributeGroups",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categorySpecificationGroups_SpecificationAttributeGroupId",
                table: "categorySpecificationGroups",
                column: "SpecificationAttributeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_specificationAttributeGroups_Categories_CategoryId",
                table: "specificationAttributeGroups",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specificationAttributeGroups_Categories_CategoryId",
                table: "specificationAttributeGroups");

            migrationBuilder.DropTable(
                name: "categorySpecificationGroups");

            migrationBuilder.DropIndex(
                name: "IX_specificationAttributeGroups_CategoryId",
                table: "specificationAttributeGroups");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "specificationAttributeGroups");
        }
    }
}
