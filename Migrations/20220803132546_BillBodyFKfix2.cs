using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaktureAPI.Migrations
{
    public partial class BillBodyFKfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillHeaders_Partners_Partner",
                table: "BillHeaders");

            migrationBuilder.DropIndex(
                name: "IX_BillHeaders_Partner",
                table: "BillHeaders");

            migrationBuilder.RenameColumn(
                name: "Partner",
                table: "BillHeaders",
                newName: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KupacId",
                table: "BillHeaders",
                newName: "Partner");

            migrationBuilder.CreateIndex(
                name: "IX_BillHeaders_Partner",
                table: "BillHeaders",
                column: "Partner");

            migrationBuilder.AddForeignKey(
                name: "FK_BillHeaders_Partners_Partner",
                table: "BillHeaders",
                column: "Partner",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
