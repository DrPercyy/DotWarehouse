using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Create02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movements_products_ProductId",
                table: "movements");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_units_UnitId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_units_UnitId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_suppliers_products_ProductId",
                table: "products_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_products_suppliers_suppliers_SupplierId",
                table: "products_suppliers");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_UnitId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UnitId1",
                table: "products");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Product",
                table: "movements",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit",
                table: "products",
                column: "UnitId",
                principalTable: "units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Product",
                table: "products_suppliers",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Supplier",
                table: "products_suppliers",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Product",
                table: "movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Product",
                table: "products_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Supplier",
                table: "products_suppliers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId1",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId1",
                table: "products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_UnitId1",
                table: "products",
                column: "UnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_movements_products_ProductId",
                table: "movements",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId1",
                table: "products",
                column: "CategoryId1",
                principalTable: "categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_units_UnitId",
                table: "products",
                column: "UnitId",
                principalTable: "units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_units_UnitId1",
                table: "products",
                column: "UnitId1",
                principalTable: "units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_suppliers_products_ProductId",
                table: "products_suppliers",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_suppliers_suppliers_SupplierId",
                table: "products_suppliers",
                column: "SupplierId",
                principalTable: "suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
