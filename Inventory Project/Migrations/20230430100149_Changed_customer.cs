using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Project.Migrations
{
    /// <inheritdoc />
    public partial class Changed_customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "customers");
        }
    }
}
