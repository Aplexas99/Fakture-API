using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaktureAPI.Migrations
{
    public partial class BillBodyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillBodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Opis = table.Column<string>(type: "text", nullable: false),
                    Kolicina = table.Column<int>(type: "integer", nullable: false),
                    CijenaDeviza = table.Column<decimal>(type: "numeric", nullable: false),
                    CijenaKm = table.Column<decimal>(type: "numeric", nullable: false),
                    Rabat = table.Column<decimal>(type: "numeric", nullable: true),
                    IznosRabata = table.Column<string>(type: "text", nullable: true),
                    PDV = table.Column<decimal>(type: "numeric", nullable: true),
                    Vrijednost = table.Column<string>(type: "text", nullable: false),
                    BillHeaderId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillBodies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillBodies");
        }
    }
}
