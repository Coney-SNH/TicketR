using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketr.Migrations
{
    public partial class AddCombineTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CombinedTime",
                table: "Series",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CombinedTime",
                table: "Series");
        }
    }
}
