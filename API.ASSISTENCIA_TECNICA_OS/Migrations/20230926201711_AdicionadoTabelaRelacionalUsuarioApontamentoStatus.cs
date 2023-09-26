using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTabelaRelacionalUsuarioApontamentoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_statusOrcamento_tab_status_StatusId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_statusOrcamento_tab_user_auth_UsuarioApontamentoFimId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_statusOrcamento_tab_user_auth_UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_statusOrcamento_StatusId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_statusOrcamento_UsuarioApontamentoFimId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_statusOrcamento_UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropColumn(
                name: "UsuarioApontamentoFimId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropColumn(
                name: "UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento");

            migrationBuilder.CreateTable(
                name: "tab_usuarioApontamentoStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusOrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioApontamentoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_usuarioApontamentoStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatus_tab_statusOrcamento_StatusOrca~",
                        column: x => x.StatusOrcamentoId,
                        principalTable: "tab_statusOrcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatus_tab_user_auth_UsuarioApontamen~",
                        column: x => x.UsuarioApontamentoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatus_StatusOrcamentoId",
                table: "tab_usuarioApontamentoStatus",
                column: "StatusOrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatus_UsuarioApontamentoId",
                table: "tab_usuarioApontamentoStatus",
                column: "UsuarioApontamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_usuarioApontamentoStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioApontamentoFimId",
                table: "tab_statusOrcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_statusOrcamento_StatusId",
                table: "tab_statusOrcamento",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_statusOrcamento_UsuarioApontamentoFimId",
                table: "tab_statusOrcamento",
                column: "UsuarioApontamentoFimId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_statusOrcamento_UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento",
                column: "UsuarioApontamentoInicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_statusOrcamento_tab_status_StatusId",
                table: "tab_statusOrcamento",
                column: "StatusId",
                principalTable: "tab_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_statusOrcamento_tab_user_auth_UsuarioApontamentoFimId",
                table: "tab_statusOrcamento",
                column: "UsuarioApontamentoFimId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_statusOrcamento_tab_user_auth_UsuarioApontamentoInicioId",
                table: "tab_statusOrcamento",
                column: "UsuarioApontamentoInicioId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
