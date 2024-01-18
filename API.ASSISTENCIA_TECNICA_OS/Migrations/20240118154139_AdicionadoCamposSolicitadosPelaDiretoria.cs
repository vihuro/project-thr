using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCamposSolicitadosPelaDiretoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroNotaOrcamentoRadar",
                table: "tab_orcamento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroOrcamentoRadar",
                table: "tab_orcamento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetorno",
                table: "tab_maquina_cliente",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSugestaoRetorno",
                table: "tab_maquina_cliente",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoAquisicao",
                table: "tab_maquina_cliente",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroNotaOrcamentoRadar",
                table: "tab_orcamento");

            migrationBuilder.DropColumn(
                name: "NumeroOrcamentoRadar",
                table: "tab_orcamento");

            migrationBuilder.DropColumn(
                name: "DataRetorno",
                table: "tab_maquina_cliente");

            migrationBuilder.DropColumn(
                name: "DataSugestaoRetorno",
                table: "tab_maquina_cliente");

            migrationBuilder.DropColumn(
                name: "TipoAquisicao",
                table: "tab_maquina_cliente");
        }
    }
}
