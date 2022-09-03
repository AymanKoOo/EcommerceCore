using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class deals2table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealDiscount_Deal_dealID",
                table: "DealDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_DealDiscount_discounts_discountID",
                table: "DealDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DealDiscount",
                table: "DealDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deal",
                table: "Deal");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Deal");

            migrationBuilder.RenameTable(
                name: "DealDiscount",
                newName: "dealDiscounts");

            migrationBuilder.RenameTable(
                name: "Deal",
                newName: "deals");

            migrationBuilder.RenameIndex(
                name: "IX_DealDiscount_discountID",
                table: "dealDiscounts",
                newName: "IX_dealDiscounts_discountID");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dealDiscounts",
                table: "dealDiscounts",
                columns: new[] { "dealID", "discountID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_deals",
                table: "deals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dealPictures",
                columns: table => new
                {
                    DealID = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealPictures", x => new { x.DealID, x.PictureId });
                    table.ForeignKey(
                        name: "FK_dealPictures_deals_DealID",
                        column: x => x.DealID,
                        principalTable: "deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dealPictures_pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dealPictures_PictureId",
                table: "dealPictures",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_dealDiscounts_deals_dealID",
                table: "dealDiscounts",
                column: "dealID",
                principalTable: "deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dealDiscounts_discounts_discountID",
                table: "dealDiscounts",
                column: "discountID",
                principalTable: "discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dealDiscounts_deals_dealID",
                table: "dealDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_dealDiscounts_discounts_discountID",
                table: "dealDiscounts");

            migrationBuilder.DropTable(
                name: "dealPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deals",
                table: "deals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dealDiscounts",
                table: "dealDiscounts");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "deals");

            migrationBuilder.RenameTable(
                name: "deals",
                newName: "Deal");

            migrationBuilder.RenameTable(
                name: "dealDiscounts",
                newName: "DealDiscount");

            migrationBuilder.RenameIndex(
                name: "IX_dealDiscounts_discountID",
                table: "DealDiscount",
                newName: "IX_DealDiscount_discountID");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Deal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deal",
                table: "Deal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DealDiscount",
                table: "DealDiscount",
                columns: new[] { "dealID", "discountID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DealDiscount_Deal_dealID",
                table: "DealDiscount",
                column: "dealID",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DealDiscount_discounts_discountID",
                table: "DealDiscount",
                column: "discountID",
                principalTable: "discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
