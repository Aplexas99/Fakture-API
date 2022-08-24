using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaktureAPI.Migrations
{
    public partial class BillHeaderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrojRacuna = table.Column<string>(type: "text", nullable: false),
                    DatumIsporuke = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DatumDokumenta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DatumDospijeca = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    Napomena = table.Column<string>(type: "text", nullable: true),
                    MjestoIzdavanja = table.Column<string>(type: "text", nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FiskalniBroj = table.Column<string>(type: "text", nullable: false),
                    Partner = table.Column<int>(type: "integer", nullable: false),
                    UkupanIznos = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillHeaders_Partners_Partner",
                        column: x => x.Partner,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillHeaders_Partner",
                table: "BillHeaders",
                column: "Partner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillHeaders");
        }
    }
}
