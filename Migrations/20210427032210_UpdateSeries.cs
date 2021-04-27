using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketr.Migrations
{
    public partial class UpdateSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedEventCode",
                table: "Series",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedEventCode",
                table: "Series");
        }
    }
}
