using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_status", x => x.Id);
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
                    CEP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Regiao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Rua = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NumeroEstabelecimento = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    ContatoTelefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NomeContatoClient = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
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
                    CodigoMaquina = table.Column<string>(type: "text", nullable: false),
                    DescricaoMaquina = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Atribuida = table.Column<bool>(type: "boolean", nullable: false),
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
                name: "tab_pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoRadar = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Unidade = table.Column<string>(type: "text", nullable: true),
                    Familia = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnderecoImagem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_pecas_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecas_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_sugestao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SugestacaoManutencao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    UsuarioSugestacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraSugestacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusSugestacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_sugestao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_sugestao_tab_user_auth_UsuarioSugestacaoId",
                        column: x => x.UsuarioSugestacaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_tecnico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_tecnico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_tecnico_tab_user_auth_UsuarioId",
                        column: x => x.UsuarioId,
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
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquina_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_maquina_cliente_tab_client_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tab_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "tab_orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoServico = table.Column<string>(type: "text", nullable: true),
                    ValorOrcamento = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaClienteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_orcamento_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_orcamento_tab_maquina_cliente_MaquinaClienteId",
                        column: x => x.MaquinaClienteId,
                        principalTable: "tab_maquina_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_orcamento_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_orcamento_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_pecasMaquinaEOrcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<double>(type: "double precision", nullable: false),
                    PecaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Conserto = table.Column<bool>(type: "boolean", nullable: false),
                    Troca = table.Column<bool>(type: "boolean", nullable: false),
                    Reaproveitamento = table.Column<bool>(type: "boolean", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_pecasMaquinaEOrcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_pecasMaquinaEOrcamento_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecasMaquinaEOrcamento_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_pecasMaquinaEOrcamento_tab_pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "tab_pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_statusOrcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_statusOrcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_statusOrcamento_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_statusOrcamento_tab_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tab_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_tecnicoManutencao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TecnicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_tecnicoManutencao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_tecnicoManutencao_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_tecnicoManutencao_tab_tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "tab_tecnico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_tecnicoOrcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TecnicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_tecnicoOrcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_tecnicoOrcamento_tab_orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "tab_orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_tecnicoOrcamento_tab_tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "tab_tecnico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_usuarioApontamentoStatusFim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusOrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioApontamentoFimId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_usuarioApontamentoStatusFim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatusFim_tab_statusOrcamento_StatusO~",
                        column: x => x.StatusOrcamentoId,
                        principalTable: "tab_statusOrcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatusFim_tab_user_auth_UsuarioAponta~",
                        column: x => x.UsuarioApontamentoFimId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_usuarioApontamentoStatusInicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusOrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioApontamentoInicioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_usuarioApontamentoStatusInicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatusInicio_tab_statusOrcamento_Stat~",
                        column: x => x.StatusOrcamentoId,
                        principalTable: "tab_statusOrcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_usuarioApontamentoStatusInicio_tab_user_auth_UsuarioApo~",
                        column: x => x.UsuarioApontamentoInicioId,
                        principalTable: "tab_user_auth",
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
                name: "IX_tab_maquina_cliente_ClienteId",
                table: "tab_maquina_cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_MaquinaId",
                table: "tab_maquina_cliente",
                column: "MaquinaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_orcamento_MaquinaClienteId",
                table: "tab_orcamento",
                column: "MaquinaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_orcamento_MaquinaId",
                table: "tab_orcamento",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_orcamento_UsuarioAlteracaoId",
                table: "tab_orcamento",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_orcamento_UsuarioCadastroId",
                table: "tab_orcamento",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_MaquinaId",
                table: "tab_pecaPorMaquina",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_PecaId",
                table: "tab_pecaPorMaquina",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_UsuarioAlteracaoId",
                table: "tab_pecas",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_UsuarioCadastroId",
                table: "tab_pecas",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_MaquinaId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_OrcamentoId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_PecaId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_statusOrcamento_OrcamentoId",
                table: "tab_statusOrcamento",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_statusOrcamento_StatusId",
                table: "tab_statusOrcamento",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_sugestao_UsuarioSugestacaoId",
                table: "tab_sugestao",
                column: "UsuarioSugestacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_tecnico_UsuarioId",
                table: "tab_tecnico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_tecnicoManutencao_OrcamentoId",
                table: "tab_tecnicoManutencao",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_tecnicoManutencao_TecnicoId",
                table: "tab_tecnicoManutencao",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_tecnicoOrcamento_OrcamentoId",
                table: "tab_tecnicoOrcamento",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_tecnicoOrcamento_TecnicoId",
                table: "tab_tecnicoOrcamento",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatusFim_StatusOrcamentoId",
                table: "tab_usuarioApontamentoStatusFim",
                column: "StatusOrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatusFim_UsuarioApontamentoFimId",
                table: "tab_usuarioApontamentoStatusFim",
                column: "UsuarioApontamentoFimId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatusInicio_StatusOrcamentoId",
                table: "tab_usuarioApontamentoStatusInicio",
                column: "StatusOrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_usuarioApontamentoStatusInicio_UsuarioApontamentoInicio~",
                table: "tab_usuarioApontamentoStatusInicio",
                column: "UsuarioApontamentoInicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_pecaPorMaquina");

            migrationBuilder.DropTable(
                name: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropTable(
                name: "tab_sugestao");

            migrationBuilder.DropTable(
                name: "tab_tecnicoManutencao");

            migrationBuilder.DropTable(
                name: "tab_tecnicoOrcamento");

            migrationBuilder.DropTable(
                name: "tab_usuarioApontamentoStatusFim");

            migrationBuilder.DropTable(
                name: "tab_usuarioApontamentoStatusInicio");

            migrationBuilder.DropTable(
                name: "tab_pecas");

            migrationBuilder.DropTable(
                name: "tab_tecnico");

            migrationBuilder.DropTable(
                name: "tab_statusOrcamento");

            migrationBuilder.DropTable(
                name: "tab_orcamento");

            migrationBuilder.DropTable(
                name: "tab_status");

            migrationBuilder.DropTable(
                name: "tab_maquina_cliente");

            migrationBuilder.DropTable(
                name: "tab_client");

            migrationBuilder.DropTable(
                name: "tab_maquina");

            migrationBuilder.DropTable(
                name: "tab_user_auth");
        }
    }
}
