using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaktureAPI.Migrations
{
    public partial class IntialDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "text", nullable: false),
                    Adresa = table.Column<string>(type: "text", nullable: false),
                    Mjesto = table.Column<string>(type: "text", nullable: false),
                    BrojPoste = table.Column<string>(type: "text", nullable: false),
                    MB = table.Column<string>(type: "text", nullable: false),
                    Pbr = table.Column<string>(type: "text", nullable: true),
                    Banka = table.Column<List<string>>(type: "text[]", nullable: true),
                    Swift = table.Column<string>(type: "text", nullable: true),
                    Tip = table.Column<bool>(type: "boolean", nullable: false),
                    Drzava = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
