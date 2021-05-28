using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestione.EF.Migrations
{
    public partial class PrimaMigrazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(maxLength: 10, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Cognome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DataOrdine = table.Column<DateTime>(nullable: false),
                    CodiceOrdine = table.Column<string>(maxLength: 10, nullable: false),
                    CodiceProdotto = table.Column<string>(maxLength: 10, nullable: false),
                    Importo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_Id",
                        column: x => x.Id,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
