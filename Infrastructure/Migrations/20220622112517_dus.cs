using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "discounts",
                newName: "PictureName");

            migrationBuilder.AddColumn<int>(
                name: "pictureId",
                table: "discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_discounts_pictureId",
                table: "discounts",
                column: "pictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_discounts_pictures_pictureId",
                table: "discounts",
                column: "pictureId",
                principalTable: "pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discounts_pictures_pictureId",
                table: "discounts");

            migrationBuilder.DropIndex(
                name: "IX_discounts_pictureId",
                table: "discounts");

            migrationBuilder.DropColumn(
                name: "pictureId",
                table: "discounts");

            migrationBuilder.RenameColumn(
                name: "PictureName",
                table: "discounts",
                newName: "Picture");
        }
    }
}
