using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    id_klienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nazwisko = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    telefon = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Klienci__EB1748C932F0DC53", x => x.id_klienta);
                });

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    id_pokoju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numer_pokoju = table.Column<int>(type: "int", nullable: false),
                    ilosc_osob = table.Column<int>(type: "int", nullable: false),
                    cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pokoje__77BD26A3E64A0FAF", x => x.id_pokoju);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    id_uslugi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uslugi__9FD22D6B4F02AA6C", x => x.id_uslugi);
                });

            migrationBuilder.CreateTable(
                name: "Pobyty",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_klienta = table.Column<int>(type: "int", nullable: false),
                    id_pokoju = table.Column<int>(type: "int", nullable: false),
                    data_przyjazdu = table.Column<DateTime>(type: "date", nullable: false),
                    zakonczony_pobyt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pobyty", x => x.id);
                    table.ForeignKey(
                        name: "FK__Pobyty__id_klien__286302EC",
                        column: x => x.id_klienta,
                        principalTable: "Klienci",
                        principalColumn: "id_klienta");
                    table.ForeignKey(
                        name: "FK__Pobyty__id_pokoj__29572725",
                        column: x => x.id_pokoju,
                        principalTable: "Pokoje",
                        principalColumn: "id_pokoju");
                });

            migrationBuilder.CreateTable(
                name: "WykupioneUslugi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_klienta = table.Column<int>(type: "int", nullable: false),
                    id_uslugi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykupioneUslugi", x => x.id);
                    table.ForeignKey(
                        name: "FK__Wykupione__id_kl__2E1BDC42",
                        column: x => x.id_klienta,
                        principalTable: "Klienci",
                        principalColumn: "id_klienta");
                    table.ForeignKey(
                        name: "FK__Wykupione__id_us__2F10007B",
                        column: x => x.id_uslugi,
                        principalTable: "Uslugi",
                        principalColumn: "id_uslugi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pobyty_id_klienta",
                table: "Pobyty",
                column: "id_klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Pobyty_id_pokoju",
                table: "Pobyty",
                column: "id_pokoju");

            migrationBuilder.CreateIndex(
                name: "IX_WykupioneUslugi_id_klienta",
                table: "WykupioneUslugi",
                column: "id_klienta");

            migrationBuilder.CreateIndex(
                name: "IX_WykupioneUslugi_id_uslugi",
                table: "WykupioneUslugi",
                column: "id_uslugi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pobyty");

            migrationBuilder.DropTable(
                name: "WykupioneUslugi");

            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Uslugi");
        }
    }
}
