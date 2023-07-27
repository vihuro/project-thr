using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelaMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_substitutos_tab_estoque_MaterialEstoqueId",
                table: "tab_substitutos");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_substitutos_tab_estoque_SubstitutoId",
                table: "tab_substitutos");

            migrationBuilder.CreateTable(
                name: "tab_movimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoMovimentacao = table.Column<string>(type: "text", nullable: true),
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatetialId = table.Column<Guid>(type: "uuid", nullable: true),
                    QuantidadeOrigem = table.Column<double>(type: "double precision", nullable: false),
                    QuantidadeDestino = table.Column<double>(type: "double precision", nullable: false),
                    NovaQuantidade = table.Column<double>(type: "double precision", nullable: false),
                    Destino = table.Column<string>(type: "text", nullable: true),
                    DataHoraMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioMovimentacaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_movimentacao_tab_estoque_MatetialId",
                        column: x => x.MatetialId,
                        principalTable: "tab_estoque",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_movimentacao_tab_user_auth_UsuarioMovimentacaoId",
                        column: x => x.UsuarioMovimentacaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_movimentacao_MatetialId",
                table: "tab_movimentacao",
                column: "MatetialId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_movimentacao_UsuarioMovimentacaoId",
                table: "tab_movimentacao",
                column: "UsuarioMovimentacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_substitutos_tab_estoque_MaterialEstoqueId",
                table: "tab_substitutos",
                column: "MaterialEstoqueId",
                principalTable: "tab_estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_substitutos_tab_estoque_SubstitutoId",
                table: "tab_substitutos",
                column: "SubstitutoId",
                principalTable: "tab_estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_substitutos_tab_estoque_MaterialEstoqueId",
                table: "tab_substitutos");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_substitutos_tab_estoque_SubstitutoId",
                table: "tab_substitutos");

            migrationBuilder.DropTable(
                name: "tab_movimentacao");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_substitutos_tab_estoque_MaterialEstoqueId",
                table: "tab_substitutos",
                column: "MaterialEstoqueId",
                principalTable: "tab_estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_substitutos_tab_estoque_SubstitutoId",
                table: "tab_substitutos",
                column: "SubstitutoId",
                principalTable: "tab_estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
