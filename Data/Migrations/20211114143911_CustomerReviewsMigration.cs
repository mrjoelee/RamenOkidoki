using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class CustomerReviewsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodCategories_foodCategoryId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_foodCategoryId",
                table: "FoodItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderSubTotalCost",
                table: "FoodOrders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<int>(
                name: "OrderTotalItems",
                table: "FoodOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryCharge",
                table: "AddOns",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<decimal>(
                name: "SalesTaxRate",
                table: "AddOns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CustomerReviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReviews", x => x.ReviewId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "OrderTotalItems",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "SalesTaxRate",
                table: "AddOns");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderSubTotalCost",
                table: "FoodOrders",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryCharge",
                table: "AddOns",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_foodCategoryId",
                table: "FoodItems",
                column: "foodCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodCategories_foodCategoryId",
                table: "FoodItems",
                column: "foodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
