using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class TakeoutOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Customers_TakeOutCustomerId",
                table: "FoodOrders");

            migrationBuilder.RenameColumn(
                name: "TakeOutCustomerId",
                table: "FoodOrders",
                newName: "RegisteredCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrders_TakeOutCustomerId",
                table: "FoodOrders",
                newName: "IX_FoodOrders_RegisteredCustomerId");

            migrationBuilder.AddColumn<string>(
                name: "NonRegisteredCustomerLastName",
                table: "FoodOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Customers_RegisteredCustomerId",
                table: "FoodOrders",
                column: "RegisteredCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Customers_RegisteredCustomerId",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "NonRegisteredCustomerLastName",
                table: "FoodOrders");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RegisteredCustomerId",
                table: "FoodOrders",
                newName: "TakeOutCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrders_RegisteredCustomerId",
                table: "FoodOrders",
                newName: "IX_FoodOrders_TakeOutCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Customers_TakeOutCustomerId",
                table: "FoodOrders",
                column: "TakeOutCustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
