using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bulkey.DataAccess.Migrations
{
    public partial class cvns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");
        }
    }
}
