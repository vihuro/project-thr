using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class adicionado_coluna_tabela_movimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_movimentacao_tab_estoque_MatetialId",
                table: "tab_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_tab_movimentacao_MatetialId",
                table: "tab_movimentacao");

            migrationBuilder.DropColumn(
                name: "MatetialId",
                table: "tab_movimentacao");

            migrationBuilder.RenameColumn(
                name: "NovaQuantidade",
                table: "tab_movimentacao",
                newName: "QuantidadeMovimentada");

            migrationBuilder.CreateIndex(
                name: "IX_tab_movimentacao_MaterialId",
                table: "tab_movimentacao",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_movimentacao_tab_estoque_MaterialId",
                table: "tab_movimentacao",
                column: "MaterialId",
                principalTable: "tab_estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_movimentacao_tab_estoque_MaterialId",
                table: "tab_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_tab_movimentacao_MaterialId",
                table: "tab_movimentacao");

            migrationBuilder.RenameColumn(
                name: "QuantidadeMovimentada",
                table: "tab_movimentacao",
                newName: "NovaQuantidade");

            migrationBuilder.AddColumn<Guid>(
                name: "MatetialId",
                table: "tab_movimentacao",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_movimentacao_MatetialId",
                table: "tab_movimentacao",
                column: "MatetialId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_movimentacao_tab_estoque_MatetialId",
                table: "tab_movimentacao",
                column: "MatetialId",
                principalTable: "tab_estoque",
                principalColumn: "Id");
        }
    }
}
