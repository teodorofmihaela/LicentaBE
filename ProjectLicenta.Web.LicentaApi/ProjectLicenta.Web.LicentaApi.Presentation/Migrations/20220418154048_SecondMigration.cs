using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Servicii",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeServiciu = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nume = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Parola = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Localitate = table.Column<string>(nullable: false),
                    Telefon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anunturi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdServiciu = table.Column<Guid>(nullable: false),
                    Titlu = table.Column<string>(type: "varchar(256)", nullable: false),
                    Text = table.Column<string>(nullable: false),
                    DataPostare = table.Column<DateTime>(nullable: false),
                    Arhivat = table.Column<bool>(nullable: false),
                    Pret = table.Column<int>(nullable: false),
                    Negociabil = table.Column<bool>(nullable: false),
                    Prestator = table.Column<bool>(nullable: false),
                    IdUtilizator = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anunturi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anunturi_Servicii_IdServiciu",
                        column: x => x.IdServiciu,
                        principalTable: "Servicii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anunturi_Utilizatori_IdUtilizator",
                        column: x => x.IdUtilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnunturiPrestate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUtilizator = table.Column<Guid>(nullable: false),
                    IdAnunt = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnunturiPrestate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnunturiPrestate_Utilizatori_IdUtilizator",
                        column: x => x.IdUtilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUtilizatorDat = table.Column<Guid>(nullable: false),
                    IdUtilizatorPrimit = table.Column<Guid>(nullable: false),
                    Titlu = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    IdServiciu = table.Column<Guid>(nullable: false),
                    NrStele = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Utilizatori_IdUtilizatorPrimit",
                        column: x => x.IdUtilizatorPrimit,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilizatoriFavoriti",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUtilizatorFavorit = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizatoriFavoriti", x => new { x.Id, x.IdUtilizatorFavorit });
                    table.ForeignKey(
                        name: "FK_UtilizatoriFavoriti_Utilizatori_IdUtilizatorFavorit",
                        column: x => x.IdUtilizatorFavorit,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cautari",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCautare = table.Column<DateTime>(nullable: false),
                    IdUtilizator = table.Column<Guid>(nullable: false),
                    IdAnunt = table.Column<Guid>(nullable: false),
                    ProfilAccesat = table.Column<bool>(nullable: false),
                    TimpPeProfil = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cautari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cautari_Anunturi_IdAnunt",
                        column: x => x.IdAnunt,
                        principalTable: "Anunturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cautari_Utilizatori_IdUtilizator",
                        column: x => x.IdUtilizator,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_IdServiciu",
                table: "Anunturi",
                column: "IdServiciu");

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_IdUtilizator",
                table: "Anunturi",
                column: "IdUtilizator");

            migrationBuilder.CreateIndex(
                name: "IX_AnunturiPrestate_IdUtilizator",
                table: "AnunturiPrestate",
                column: "IdUtilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_IdAnunt",
                table: "Cautari",
                column: "IdAnunt");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_IdUtilizator",
                table: "Cautari",
                column: "IdUtilizator");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_IdUtilizatorPrimit",
                table: "FeedBacks",
                column: "IdUtilizatorPrimit");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriFavoriti_IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti",
                column: "IdUtilizatorFavorit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnunturiPrestate");

            migrationBuilder.DropTable(
                name: "Cautari");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "UtilizatoriFavoriti");

            migrationBuilder.DropTable(
                name: "Anunturi");

            migrationBuilder.DropTable(
                name: "Servicii");

            migrationBuilder.DropTable(
                name: "Utilizatori");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET latin1", nullable: false),
                    Password = table.Column<string>(type: "longtext CHARACTER SET latin1", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
