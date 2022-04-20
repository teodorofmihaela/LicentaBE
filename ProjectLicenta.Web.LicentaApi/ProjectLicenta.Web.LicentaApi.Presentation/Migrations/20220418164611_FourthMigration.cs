using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdUtilizator",
                table: "Anunturi",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UtilizatorId",
                table: "Anunturi",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Anunturi_UtilizatorId",
                table: "Anunturi",
                column: "UtilizatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anunturi_Utilizatori_UtilizatorId",
                table: "Anunturi",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anunturi_Utilizatori_UtilizatorId",
                table: "Anunturi");

            migrationBuilder.DropIndex(
                name: "IX_Anunturi_UtilizatorId",
                table: "Anunturi");

            migrationBuilder.DropColumn(
                name: "IdUtilizator",
                table: "Anunturi");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Anunturi");
        }
    }
}
