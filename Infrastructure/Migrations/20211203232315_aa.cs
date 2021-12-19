using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "products",
                newName: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "UnitPrice");
        }
    }
}
