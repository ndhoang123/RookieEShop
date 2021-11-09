using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class Configureordername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "N'RE'+ RIGHT('0000000'+CAST(OrderDetailId AS VARCHAR(7)),7)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "N'RE'+ RIGHT('0000000'+CAST(OrderDetailId AS VARCHAR(7)),7)");
        }
    }
}
