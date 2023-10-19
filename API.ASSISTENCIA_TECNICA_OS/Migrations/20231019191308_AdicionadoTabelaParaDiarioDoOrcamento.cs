using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTabelaParaDiarioDoOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_diarioOrcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroOrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    Informacao = table.Column<string>(type: "text", nullable: true),
                    Tag = table.Column<string>(type: "text", nullable: true),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioApontamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraApontamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_diarioOrcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_diarioOrcamento_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_diarioOrcamento_tab_user_auth_UsuarioApontamentoId",
                        column: x => x.UsuarioApontamentoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_diarioOrcamento_OrcamentoId",
                table: "tab_diarioOrcamento",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_diarioOrcamento_UsuarioApontamentoId",
                table: "tab_diarioOrcamento",
                column: "UsuarioApontamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_diarioOrcamento");
        }
    }
}
