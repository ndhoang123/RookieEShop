using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class AddDisableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisableProduct",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisableProduct",
                table: "Products");
        }
    }
}
