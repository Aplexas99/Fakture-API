using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaktureAPI.Migrations
{
    public partial class BillBodyFKfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BillHeaderId",
                table: "BillBodies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BillHeaderId",
                table: "BillBodies",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
