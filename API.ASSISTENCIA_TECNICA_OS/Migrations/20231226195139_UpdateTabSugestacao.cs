using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabSugestacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCobranca",
                table: "tab_sugestao",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "MaquinaId",
                table: "tab_sugestao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "StatusSugestao",
                table: "tab_sugestao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "tab_orcamento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Privado",
                table: "tab_diarioOrcamento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_tab_sugestao_MaquinaId",
                table: "tab_sugestao",
                column: "MaquinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_sugestao_tab_maquina_MaquinaId",
                table: "tab_sugestao",
                column: "MaquinaId",
                principalTable: "tab_maquina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_sugestao_tab_maquina_MaquinaId",
                table: "tab_sugestao");

            migrationBuilder.DropIndex(
                name: "IX_tab_sugestao_MaquinaId",
                table: "tab_sugestao");

            migrationBuilder.DropColumn(
                name: "DataCobranca",
                table: "tab_sugestao");

            migrationBuilder.DropColumn(
                name: "MaquinaId",
                table: "tab_sugestao");

            migrationBuilder.DropColumn(
                name: "StatusSugestao",
                table: "tab_sugestao");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "tab_orcamento");

            migrationBuilder.DropColumn(
                name: "Privado",
                table: "tab_diarioOrcamento");
        }
    }
}
