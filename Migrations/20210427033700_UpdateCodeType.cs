using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketr.Migrations
{
    public partial class UpdateCodeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RelatedEventCode",
                table: "Series",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RelatedEventCode",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
