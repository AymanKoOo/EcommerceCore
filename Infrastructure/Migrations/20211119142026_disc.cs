using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class disc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discounts_DiscountTypeId",
                table: "discounts",
                column: "DiscountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_discounts_DiscountType_DiscountTypeId",
                table: "discounts",
                column: "DiscountTypeId",
                principalTable: "DiscountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discounts_DiscountType_DiscountTypeId",
                table: "discounts");

            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropIndex(
                name: "IX_discounts_DiscountTypeId",
                table: "discounts");
        }
    }
}
