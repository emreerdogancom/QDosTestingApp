using Microsoft.EntityFrameworkCore.Migrations;

namespace SupplierApp.Migrations
{
    public partial class updatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceIncludedTax",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "([UnitPrice] + ([UnitPrice] * ([Tax] / 100))) AS decimal(18,2)",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComputedColumnSql: "[UnitPrice] + ([UnitPrice] * ([Tax] / 100))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceIncludedTax",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "[UnitPrice] + ([UnitPrice] * ([Tax] / 100))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComputedColumnSql: "([UnitPrice] + ([UnitPrice] * ([Tax] / 100))) AS decimal(18,2)");
        }
    }
}
