using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class RemovedRelationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Utilizatori_UtilizatorId",
                table: "FeedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "IdUtilizator",
                table: "Anunturi");

            migrationBuilder.RenameTable(
                name: "FeedBacks",
                newName: "Feedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBacks_UtilizatorId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_UtilizatorId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnunturiId",
                table: "Cautari",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cautari_AnunturiId",
                table: "Cautari",
                column: "AnunturiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cautari_Anunturi_AnunturiId",
                table: "Cautari",
                column: "AnunturiId",
                principalTable: "Anunturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Utilizatori_UtilizatorId",
                table: "Feedbacks",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cautari_Anunturi_AnunturiId",
                table: "Cautari");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Utilizatori_UtilizatorId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Cautari_AnunturiId",
                table: "Cautari");

            migrationBuilder.DropColumn(
                name: "IdUtilizatorFavorit",
                table: "UtilizatoriFavoriti");

            migrationBuilder.DropColumn(
                name: "AnunturiId",
                table: "Cautari");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "FeedBacks");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_UtilizatorId",
                table: "FeedBacks",
                newName: "IX_FeedBacks_UtilizatorId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUtilizator",
                table: "Anunturi",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Utilizatori_UtilizatorId",
                table: "FeedBacks",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
