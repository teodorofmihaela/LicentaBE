using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anunturi_Servicii_IdServiciu",
                table: "Anunturi");

            migrationBuilder.DropForeignKey(
                name: "FK_Anunturi_Utilizatori_IdUtilizator",
                table: "Anunturi");

            migrationBuilder.DropForeignKey(
                name: "FK_AnunturiPrestate_Utilizatori_IdUtilizator",
                table: "AnunturiPrestate");

            migrationBuilder.DropForeignKey(
                name: "FK_Cautari_Anunturi_IdAnunt",
                table: "Cautari");

            migrationBuilder.DropForeignKey(
                name: "FK_Cautari_Utilizatori_IdUtilizator",
                table: "Cautari");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Utilizatori_IdUtilizatorPrimit",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilizatoriFavoriti_Utilizatori_IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilizatoriFavoriti",
                table: "UtilizatoriFavoriti");

            migrationBuilder.DropIndex(
                name: "IX_UtilizatoriFavoriti_IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_IdUtilizatorPrimit",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_Cautari_IdAnunt",
                table: "Cautari");

            migrationBuilder.DropIndex(
                name: "IX_Cautari_IdUtilizator",
                table: "Cautari");

            migrationBuilder.DropIndex(
                name: "IX_AnunturiPrestate_IdUtilizator",
                table: "AnunturiPrestate");

            migrationBuilder.DropIndex(
                name: "IX_Anunturi_IdServiciu",
                table: "Anunturi");

            migrationBuilder.DropIndex(
                name: "IX_Anunturi_IdUtilizator",
                table: "Anunturi");

            migrationBuilder.DropColumn(
                name: "IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti");

            migrationBuilder.DropColumn(
                name: "IdUtilizator",
                table: "Anunturi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilizatoriFavoriti",
                table: "UtilizatoriFavoriti",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilizatoriFavoriti",
                table: "UtilizatoriFavoriti");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUtilizator",
                table: "Anunturi",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilizatoriFavoriti",
                table: "UtilizatoriFavoriti",
                columns: new[] { "Id", "IdUtilizatorFavorit" });

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatoriFavoriti_IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti",
                column: "IdUtilizatorFavorit");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_IdUtilizatorPrimit",
                table: "FeedBacks",
                column: "IdUtilizatorPrimit");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_IdAnunt",
                table: "Cautari",
                column: "IdAnunt");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_IdUtilizator",
                table: "Cautari",
                column: "IdUtilizator");

            migrationBuilder.CreateIndex(
                name: "IX_AnunturiPrestate_IdUtilizator",
                table: "AnunturiPrestate",
                column: "IdUtilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_IdServiciu",
                table: "Anunturi",
                column: "IdServiciu");

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_IdUtilizator",
                table: "Anunturi",
                column: "IdUtilizator");

            migrationBuilder.AddForeignKey(
                name: "FK_Anunturi_Servicii_IdServiciu",
                table: "Anunturi",
                column: "IdServiciu",
                principalTable: "Servicii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anunturi_Utilizatori_IdUtilizator",
                table: "Anunturi",
                column: "IdUtilizator",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnunturiPrestate_Utilizatori_IdUtilizator",
                table: "AnunturiPrestate",
                column: "IdUtilizator",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cautari_Anunturi_IdAnunt",
                table: "Cautari",
                column: "IdAnunt",
                principalTable: "Anunturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cautari_Utilizatori_IdUtilizator",
                table: "Cautari",
                column: "IdUtilizator",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Utilizatori_IdUtilizatorPrimit",
                table: "FeedBacks",
                column: "IdUtilizatorPrimit",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilizatoriFavoriti_Utilizatori_IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti",
                column: "IdUtilizatorFavorit",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
