using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Project.Migrations
{
    /// <inheritdoc />
    public partial class updatedproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productUnits_ProductUnitId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductUnitId",
                table: "products",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductUnitId",
                table: "products",
                newName: "IX_products_UnitId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "productUnits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productUnits_ProductId",
                table: "productUnits",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_units_UnitId",
                table: "products",
                column: "UnitId",
                principalTable: "units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productUnits_products_ProductId",
                table: "productUnits",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_units_UnitId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productUnits_products_ProductId",
                table: "productUnits");

            migrationBuilder.DropIndex(
                name: "IX_productUnits_ProductId",
                table: "productUnits");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "productUnits");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "products",
                newName: "ProductUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_products_UnitId",
                table: "products",
                newName: "IX_products_ProductUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productUnits_ProductUnitId",
                table: "products",
                column: "ProductUnitId",
                principalTable: "productUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
