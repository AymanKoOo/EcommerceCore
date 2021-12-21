using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addingspecificatioan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specificationAttributeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationAttributeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specificationAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId",
                        column: x => x.SpecificationAttributeGroupId,
                        principalTable: "specificationAttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    specificationAttributeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId",
                        column: x => x.specificationAttributeId,
                        principalTable: "specificationAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeOptions_specificationAttributeId",
                table: "SpecificationAttributeOptions",
                column: "specificationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_specificationAttributes_SpecificationAttributeGroupId",
                table: "specificationAttributes",
                column: "SpecificationAttributeGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationAttributeOptions");

            migrationBuilder.DropTable(
                name: "specificationAttributes");

            migrationBuilder.DropTable(
                name: "specificationAttributeGroups");
        }
    }
}
