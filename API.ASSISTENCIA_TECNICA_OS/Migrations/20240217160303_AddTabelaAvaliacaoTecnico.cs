using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaAvaliacaoTecnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_avalicao_tecnico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    TecnicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Avaliacao = table.Column<int>(type: "integer", nullable: false),
                    StatusAvaliacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_avalicao_tecnico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_avalicao_tecnico_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_avalicao_tecnico_tab_tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "tab_tecnico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_avalicao_tecnico_OrcamentoId",
                table: "tab_avalicao_tecnico",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_avalicao_tecnico_TecnicoId",
                table: "tab_avalicao_tecnico",
                column: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_avalicao_tecnico");
        }
    }
}
