using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orderings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orderings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orderings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Orderings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");
        }
    }
}
