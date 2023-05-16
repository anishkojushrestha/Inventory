using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Project.Migrations
{
    /// <inheritdoc />
    public partial class Added_product_columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductUnitId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "products",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductUnitId",
                table: "products",
                column: "ProductUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productUnits_ProductUnitId",
                table: "products",
                column: "ProductUnitId",
                principalTable: "productUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productUnits_ProductUnitId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductUnitId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductUnitId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "products");
        }
    }
}
