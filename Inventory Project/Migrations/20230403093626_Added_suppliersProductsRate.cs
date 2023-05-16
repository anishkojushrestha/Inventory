using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Project.Migrations
{
    /// <inheritdoc />
    public partial class Added_suppliersProductsRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliersProductsRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliersProductsRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_suppliersProductsRate_suppliersProducts_SupplierProductId",
                        column: x => x.SupplierProductId,
                        principalTable: "suppliersProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_suppliersProductsRate_units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_productUnits_UnitId",
                table: "productUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliersProductsRate_SupplierProductId",
                table: "suppliersProductsRate",
                column: "SupplierProductId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliersProductsRate_UnitId",
                table: "suppliersProductsRate",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_productUnits_units_UnitId",
                table: "productUnits",
                column: "UnitId",
                principalTable: "units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productUnits_units_UnitId",
                table: "productUnits");

            migrationBuilder.DropTable(
                name: "suppliersProductsRate");

            migrationBuilder.DropIndex(
                name: "IX_productUnits_UnitId",
                table: "productUnits");
        }
    }
}
