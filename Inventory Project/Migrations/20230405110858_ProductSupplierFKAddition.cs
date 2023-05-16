using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Project.Migrations
{
    /// <inheritdoc />
    public partial class ProductSupplierFKAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "suppliersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliersProducts_ProductId",
                table: "suppliersProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliersProducts_SupplierId",
                table: "suppliersProducts",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_suppliersProducts_products_ProductId",
                table: "suppliersProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliersProducts_suppliers_SupplierId",
                table: "suppliersProducts",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliersProducts_products_ProductId",
                table: "suppliersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliersProducts_suppliers_SupplierId",
                table: "suppliersProducts");

            migrationBuilder.DropIndex(
                name: "IX_suppliersProducts_ProductId",
                table: "suppliersProducts");

            migrationBuilder.DropIndex(
                name: "IX_suppliersProducts_SupplierId",
                table: "suppliersProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "suppliersProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
