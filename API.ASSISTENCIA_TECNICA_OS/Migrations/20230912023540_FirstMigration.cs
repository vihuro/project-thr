using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_ordemServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ordemServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    EnderecoImagem = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_user_auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_user_auth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CodigoRadar = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    NomeContatoClient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ContatoTelefone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_client_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_client_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_maquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoMaquina = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NumeroSerie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_maquina_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_maquina_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_maquina_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquina_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_maquina_cliente_tab_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tab_client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_maquina_cliente_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
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

            migrationBuilder.CreateTable(
                name: "tab_pecas_por_maquina_ordem_servico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PecaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Conserto = table.Column<bool>(type: "boolean", nullable: false),
                    Troca = table.Column<bool>(type: "boolean", nullable: false),
                    OrdemServicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecas_por_maquina_ordem_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_pecas_por_maquina_ordem_servico_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecas_por_maquina_ordem_servico_tab_ordemServico_OrdemS~",
                        column: x => x.OrdemServicoId,
                        principalTable: "tab_ordemServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecas_por_maquina_ordem_servico_tab_pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "tab_pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_client_UsuarioAlteracaoId",
                table: "tab_client",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_client_UsuarioCadastroId",
                table: "tab_client",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_UsuarioAlteracaoId",
                table: "tab_maquina",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_UsuarioCadastroId",
                table: "tab_maquina",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_ClientId",
                table: "tab_maquina_cliente",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_MaquinaId",
                table: "tab_maquina_cliente",
                column: "MaquinaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_MaquinaId",
                table: "tab_pecaPorMaquina",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_PecaId",
                table: "tab_pecaPorMaquina",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_por_maquina_ordem_servico_MaquinaId",
                table: "tab_pecas_por_maquina_ordem_servico",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_por_maquina_ordem_servico_OrdemServicoId",
                table: "tab_pecas_por_maquina_ordem_servico",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_por_maquina_ordem_servico_PecaId",
                table: "tab_pecas_por_maquina_ordem_servico",
                column: "PecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_maquina_cliente");

            migrationBuilder.DropTable(
                name: "tab_pecaPorMaquina");

            migrationBuilder.DropTable(
                name: "tab_pecas_por_maquina_ordem_servico");

            migrationBuilder.DropTable(
                name: "tab_client");

            migrationBuilder.DropTable(
                name: "tab_maquina");

            migrationBuilder.DropTable(
                name: "tab_ordemServico");

            migrationBuilder.DropTable(
                name: "tab_pecas");

            migrationBuilder.DropTable(
                name: "tab_user_auth");
        }
    }
}
