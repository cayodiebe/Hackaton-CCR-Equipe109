using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipe109_Hackaton_CCR.Data.Migrations
{
    public partial class UpdateRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VagasModel_EmpresaModels_EmpresaModelIdEmpresa",
                table: "VagasModel");

            migrationBuilder.DropIndex(
                name: "IX_VagasModel_EmpresaModelIdEmpresa",
                table: "VagasModel");

            migrationBuilder.DropColumn(
                name: "EmpresaModelIdEmpresa",
                table: "VagasModel");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaModel",
                table: "VagasModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaModel",
                table: "VagasModel");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaModelIdEmpresa",
                table: "VagasModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VagasModel_EmpresaModelIdEmpresa",
                table: "VagasModel",
                column: "EmpresaModelIdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_VagasModel_EmpresaModels_EmpresaModelIdEmpresa",
                table: "VagasModel",
                column: "EmpresaModelIdEmpresa",
                principalTable: "EmpresaModels",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
