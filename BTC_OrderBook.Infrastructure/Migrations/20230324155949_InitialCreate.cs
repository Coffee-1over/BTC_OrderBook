using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTC_OrderBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDER_BOOKS",
                columns: table => new
                {
                    ID_ORDER_BOOK = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIMESTAMP = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_BOOKS", x => x.ID_ORDER_BOOK);
                });

            migrationBuilder.CreateTable(
                name: "TRADE_ORDERS",
                columns: table => new
                {
                    ID_TRADE_ORDER = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IS_BUY = table.Column<bool>(type: "bit", nullable: false),
                    OrderBookEntityId = table.Column<long>(type: "bigint", nullable: true),
                    OrderBookEntityId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRADE_ORDERS", x => x.ID_TRADE_ORDER);
                    table.ForeignKey(
                        name: "FK_TRADE_ORDERS_ORDER_BOOKS_OrderBookEntityId",
                        column: x => x.OrderBookEntityId,
                        principalTable: "ORDER_BOOKS",
                        principalColumn: "ID_ORDER_BOOK");
                    table.ForeignKey(
                        name: "FK_TRADE_ORDERS_ORDER_BOOKS_OrderBookEntityId1",
                        column: x => x.OrderBookEntityId1,
                        principalTable: "ORDER_BOOKS",
                        principalColumn: "ID_ORDER_BOOK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRADE_ORDERS_OrderBookEntityId",
                table: "TRADE_ORDERS",
                column: "OrderBookEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TRADE_ORDERS_OrderBookEntityId1",
                table: "TRADE_ORDERS",
                column: "OrderBookEntityId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRADE_ORDERS");

            migrationBuilder.DropTable(
                name: "ORDER_BOOKS");
        }
    }
}
