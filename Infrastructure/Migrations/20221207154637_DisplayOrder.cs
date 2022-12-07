using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "pictures");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "productPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "dealPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "categoryPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "productPictures");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "dealPictures");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "categoryPictures");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
