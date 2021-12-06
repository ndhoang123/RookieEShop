using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class updateOrderAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_OrderAddress_ShippingAddressId",
                table: "Orderings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderAddress",
                table: "OrderAddress");

            migrationBuilder.RenameTable(
                name: "OrderAddress",
                newName: "OrderAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderAddresses",
                table: "OrderAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_OrderAddresses_ShippingAddressId",
                table: "Orderings",
                column: "ShippingAddressId",
                principalTable: "OrderAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_OrderAddresses_ShippingAddressId",
                table: "Orderings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderAddresses",
                table: "OrderAddresses");

            migrationBuilder.RenameTable(
                name: "OrderAddresses",
                newName: "OrderAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderAddress",
                table: "OrderAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_OrderAddress_ShippingAddressId",
                table: "Orderings",
                column: "ShippingAddressId",
                principalTable: "OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
