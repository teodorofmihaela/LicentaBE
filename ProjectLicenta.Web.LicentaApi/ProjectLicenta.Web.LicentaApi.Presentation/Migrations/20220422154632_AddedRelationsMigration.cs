using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class AddedRelationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Titlu = table.Column<string>(type: "varchar(256)", nullable: false),
                    Text = table.Column<string>(nullable: false),
                    DataPostare = table.Column<DateTime>(nullable: false),
                    Arhivat = table.Column<bool>(nullable: false),
                    Pret = table.Column<int>(nullable: false),
                    Negociabil = table.Column<bool>(nullable: false),
                    Prestator = table.Column<bool>(nullable: false),
                    ServiciuId = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anunturi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anunturi_Servicii_ServiciuId",
                        column: x => x.ServiciuId,
                        principalTable: "Servicii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anunturi_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
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
                    ProfilAccesat = table.Column<bool>(nullable: false),
                    TimpPeProfil = table.Column<float>(nullable: false),
                    AnuntId = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cautari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cautari_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnunturiPrestate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    AnuntId = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnunturiPrestate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnunturiPrestate_Anunturi_AnuntId",
                        column: x => x.AnuntId,
                        principalTable: "Anunturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnunturiPrestate_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titlu = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    NrStele = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ServiciuId = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false),
                    AnuntId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Anunturi_AnuntId",
                        column: x => x.AnuntId,
                        principalTable: "Anunturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Servicii_ServiciuId",
                        column: x => x.ServiciuId,
                        principalTable: "Servicii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilizatoriFavoriti",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false),
                    AnuntId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizatoriFavoriti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilizatoriFavoriti_Anunturi_AnuntId",
                        column: x => x.AnuntId,
                        principalTable: "Anunturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilizatoriFavoriti_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_ServiciuId",
                table: "Anunturi",
                column: "ServiciuId");

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_UtilizatorId",
                table: "Anunturi",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnunturiPrestate_AnuntId",
                table: "AnunturiPrestate",
                column: "AnuntId");

            migrationBuilder.CreateIndex(
                name: "IX_AnunturiPrestate_UtilizatorId",
                table: "AnunturiPrestate",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_UtilizatorId",
                table: "Cautari",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AnuntId",
                table: "Feedbacks",
                column: "AnuntId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ServiciuId",
                table: "Feedbacks",
                column: "ServiciuId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UtilizatorId",
                table: "Feedbacks",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriFavoriti_AnuntId",
                table: "UtilizatoriFavoriti",
                column: "AnuntId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriFavoriti_UtilizatorId",
                table: "UtilizatoriFavoriti",
                column: "UtilizatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnunturiPrestate");

            migrationBuilder.DropTable(
                name: "Cautari");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "UtilizatoriFavoriti");

            migrationBuilder.DropTable(
                name: "Anunturi");

            migrationBuilder.DropTable(
                name: "Servicii");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
