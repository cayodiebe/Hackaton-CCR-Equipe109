using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipe109_Hackaton_CCR.Data.Migrations
{
    public partial class AddHOme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HomeId",
                table: "VagasModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VagasModel_HomeId",
                table: "VagasModel",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VagasModel_Home_HomeId",
                table: "VagasModel",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VagasModel_Home_HomeId",
                table: "VagasModel");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropIndex(
                name: "IX_VagasModel_HomeId",
                table: "VagasModel");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "VagasModel");
        }
    }
}
