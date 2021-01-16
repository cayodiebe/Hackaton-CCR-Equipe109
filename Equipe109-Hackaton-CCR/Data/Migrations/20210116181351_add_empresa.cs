using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipe109_Hackaton_CCR.Data.Migrations
{
    public partial class add_empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaModels",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    Ramo = table.Column<string>(nullable: false),
                    QtdeFuncionarios = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaModels", x => x.IdEmpresa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaModels");
        }
    }
}
