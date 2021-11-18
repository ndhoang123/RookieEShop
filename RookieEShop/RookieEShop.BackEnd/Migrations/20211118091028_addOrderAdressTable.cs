using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class addOrderAdressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "StatusCart",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orderings",
                newName: "StatusCart");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetails",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                table: "Orderings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CouponName",
                table: "Orderings",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orderings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "Orderings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentFee",
                table: "Orderings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orderings",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShippingAddressId",
                table: "Orderings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingFee",
                table: "Orderings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethod",
                table: "Orderings",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Orderings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orderings",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "N'RE'+ RIGHT('0000000'+CAST(Id AS VARCHAR(7)),7)");

            migrationBuilder.CreateTable(
                name: "OrderAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Phone = table.Column<int>(type: "int", maxLength: 450, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    District = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    City = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_ShippingAddressId",
                table: "Orderings",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_OrderAddress_ShippingAddressId",
                table: "Orderings",
                column: "ShippingAddressId",
                principalTable: "OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_OrderAddress_ShippingAddressId",
                table: "Orderings");

            migrationBuilder.DropTable(
                name: "OrderAddress");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_ShippingAddressId",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "CouponName",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "PaymentFee",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Orderings");

            migrationBuilder.RenameColumn(
                name: "StatusCart",
                table: "Orderings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetails",
                newName: "OrderDetailId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orderings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Orderings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StatusCart",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "N'RE'+ RIGHT('0000000'+CAST(OrderDetailId AS VARCHAR(7)),7)");
        }
    }
}
