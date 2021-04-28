using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketr.Migrations
{
    public partial class fixedPatronDonationsTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDonations",
                table: "Patrons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalDonations",
                table: "Patrons",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
