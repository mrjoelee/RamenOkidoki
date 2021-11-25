using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class OrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodOrders_FoodOrderId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_FoodOrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FoodOrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "FoodItems");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_FoodOrders_FoodOrderId",
                        column: x => x.FoodOrderId,
                        principalTable: "FoodOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_FoodOrderId",
                table: "OrderItem",
                column: "FoodOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FoodOrderId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodOrderId",
                table: "FoodItems",
                column: "FoodOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodOrders_FoodOrderId",
                table: "FoodItems",
                column: "FoodOrderId",
                principalTable: "FoodOrders",
                principalColumn: "Id");
        }
    }
}
