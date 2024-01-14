using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konya_Zoltan_Proiect_Managementul_Concediilor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieCerere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrCategorieCerere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeCategorieCerere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieCerere", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrDepartament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeDepartament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrFunctie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeFunctie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StareCerere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrStareCerere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeStareCerere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StareCerere", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DepartamentID = table.Column<int>(type: "int", nullable: true),
                    FunctieID = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Angajat_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Angajat_Functie_FunctieID",
                        column: x => x.FunctieID,
                        principalTable: "Functie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cerere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatID = table.Column<int>(type: "int", nullable: true),
                    DepartamentID = table.Column<int>(type: "int", nullable: true),
                    FunctieID = table.Column<int>(type: "int", nullable: true),
                    CategorieCerereID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StareCerereID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cerere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cerere_Angajat_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Angajat",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cerere_CategorieCerere_CategorieCerereID",
                        column: x => x.CategorieCerereID,
                        principalTable: "CategorieCerere",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cerere_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cerere_Functie_FunctieID",
                        column: x => x.FunctieID,
                        principalTable: "Functie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cerere_StareCerere_StareCerereID",
                        column: x => x.StareCerereID,
                        principalTable: "StareCerere",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_DepartamentID",
                table: "Angajat",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_FunctieID",
                table: "Angajat",
                column: "FunctieID");

            migrationBuilder.CreateIndex(
                name: "IX_Cerere_AngajatID",
                table: "Cerere",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_Cerere_CategorieCerereID",
                table: "Cerere",
                column: "CategorieCerereID");

            migrationBuilder.CreateIndex(
                name: "IX_Cerere_DepartamentID",
                table: "Cerere",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cerere_FunctieID",
                table: "Cerere",
                column: "FunctieID");

            migrationBuilder.CreateIndex(
                name: "IX_Cerere_StareCerereID",
                table: "Cerere",
                column: "StareCerereID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cerere");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropTable(
                name: "CategorieCerere");

            migrationBuilder.DropTable(
                name: "StareCerere");

            migrationBuilder.DropTable(
                name: "Departament");

            migrationBuilder.DropTable(
                name: "Functie");
        }
    }
}
