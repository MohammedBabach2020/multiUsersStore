using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiUserStore.Migrations
{
    /// <inheritdoc />
    public partial class order_ordeDetails_with_relations_delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_client_id",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_client_id",
                table: "Orders",
                column: "client_id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_client_id",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_client_id",
                table: "Orders",
                column: "client_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
