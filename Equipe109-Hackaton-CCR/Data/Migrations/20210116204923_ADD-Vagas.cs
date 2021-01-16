using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipe109_Hackaton_CCR.Data.Migrations
{
    public partial class ADDVagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "EmpresaModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VagasModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataExpiracao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<string>(nullable: false),
                    EmpresaModelIdEmpresa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagasModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagasModel_EmpresaModels_EmpresaModelIdEmpresa",
                        column: x => x.EmpresaModelIdEmpresa,
                        principalTable: "EmpresaModels",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VagasModel_EmpresaModelIdEmpresa",
                table: "VagasModel",
                column: "EmpresaModelIdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VagasModel");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "EmpresaModels");
        }
    }
}
