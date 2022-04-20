using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Migrations
{
    public partial class FKUtilizatoriAnunturiFeedBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UtilizatorId",
                table: "FeedBacks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UtilizatorId",
                table: "FeedBacks",
                column: "UtilizatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Utilizatori_UtilizatorId",
                table: "FeedBacks",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Utilizatori_UtilizatorId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_UtilizatorId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "FeedBacks");
        }
    }
}
