using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.SQL.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orders_productId",
                table: "orders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Products_productId",
                table: "orders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Products_productId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_productId",
                table: "orders");
        }
    }
}
