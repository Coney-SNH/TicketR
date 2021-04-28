using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketr.Migrations
{
    public partial class purchasedTicketfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "PurchasedTickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTickets_SeriesId",
                table: "PurchasedTickets",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedTickets_Series_SeriesId",
                table: "PurchasedTickets",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedTickets_Series_SeriesId",
                table: "PurchasedTickets");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedTickets_SeriesId",
                table: "PurchasedTickets");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "PurchasedTickets");
        }
    }
}
