using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieEShop.BackEnd.Migrations
{
    public partial class updateOrderTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_OrderDetails_OrderDetailId",
                table: "OrderTrackings");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderTrackings",
                newName: "OrderingId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTrackings_OrderDetailId",
                table: "OrderTrackings",
                newName: "IX_OrderTrackings_OrderingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Orderings_OrderingId",
                table: "OrderTrackings",
                column: "OrderingId",
                principalTable: "Orderings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Orderings_OrderingId",
                table: "OrderTrackings");

            migrationBuilder.RenameColumn(
                name: "OrderingId",
                table: "OrderTrackings",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTrackings_OrderingId",
                table: "OrderTrackings",
                newName: "IX_OrderTrackings_OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_OrderDetails_OrderDetailId",
                table: "OrderTrackings",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
