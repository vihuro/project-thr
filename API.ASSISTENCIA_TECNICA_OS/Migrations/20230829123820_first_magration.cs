using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class first_magration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_maquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoMaquina = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_ordemServico",
                columns: table => new
                {
                    Os = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ordemServico", x => x.Os);
                });

            migrationBuilder.CreateTable(
                name: "tab_pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    EndereçoImagem = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_maquinaPorOs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OsId = table.Column<int>(type: "integer", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquinaPorOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_maquinaPorOs_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_maquinaPorOs_tab_ordemServico_OsId",
                        column: x => x.OsId,
                        principalTable: "tab_ordemServico",
                        principalColumn: "Os",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_pecaPorMaquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PecaId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecaPorMaquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_pecaPorMaquina_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecaPorMaquina_tab_pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "tab_pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquinaPorOs_MaquinaId",
                table: "tab_maquinaPorOs",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquinaPorOs_OsId",
                table: "tab_maquinaPorOs",
                column: "OsId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_MaquinaId",
                table: "tab_pecaPorMaquina",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_PecaId",
                table: "tab_pecaPorMaquina",
                column: "PecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_maquinaPorOs");

            migrationBuilder.DropTable(
                name: "tab_pecaPorMaquina");

            migrationBuilder.DropTable(
                name: "tab_user");

            migrationBuilder.DropTable(
                name: "tab_ordemServico");

            migrationBuilder.DropTable(
                name: "tab_maquina");

            migrationBuilder.DropTable(
                name: "tab_pecas");
        }
    }
}
