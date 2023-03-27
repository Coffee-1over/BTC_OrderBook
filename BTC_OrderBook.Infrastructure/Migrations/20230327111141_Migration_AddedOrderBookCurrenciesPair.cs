using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTC_OrderBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_AddedOrderBookCurrenciesPair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.AddColumn<string>(
                name: "CURRENCIES_PAIR",
                table: "ORDER_BOOKS",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "btceur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CURRENCIES_PAIR",
                table: "ORDER_BOOKS");
        }
    }
}
