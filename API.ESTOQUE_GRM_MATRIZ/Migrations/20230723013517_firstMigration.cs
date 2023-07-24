using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_user_auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Apelido = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_user_auth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalArmazenagemModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Local = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalArmazenagemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_tipo_matetial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoMaterial = table.Column<string>(type: "text", nullable: true),
                    UserRegisterId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTimeRegister = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserChangeId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_tipo_matetial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_tipo_matetial_tab_user_auth_UserChangeId",
                        column: x => x.UserChangeId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_tipo_matetial_tab_user_auth_UserRegisterId",
                        column: x => x.UserRegisterId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Quantidade = table.Column<double>(type: "double precision", nullable: false),
                    TipoMaterialId = table.Column<Guid>(type: "uuid", nullable: true),
                    Unidade = table.Column<string>(type: "text", nullable: true),
                    LocalArmazenagemId = table.Column<Guid>(type: "uuid", nullable: true),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadstro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_estoque_LocalArmazenagemModel_LocalArmazenagemId",
                        column: x => x.LocalArmazenagemId,
                        principalTable: "LocalArmazenagemModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_estoque_tab_tipo_matetial_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalTable: "tab_tipo_matetial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_estoque_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_estoque_tab_user_auth_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_substitutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialEstoqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubstitutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioCadatroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadatro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_substitutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_substitutos_tab_estoque_MaterialEstoqueId",
                        column: x => x.MaterialEstoqueId,
                        principalTable: "tab_estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_substitutos_tab_estoque_SubstitutoId",
                        column: x => x.SubstitutoId,
                        principalTable: "tab_estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_substitutos_tab_user_auth_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_substitutos_tab_user_auth_UsuarioCadatroId",
                        column: x => x.UsuarioCadatroId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalArmazenagemModel_UsuarioAlteracaoId",
                table: "LocalArmazenagemModel",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalArmazenagemModel_UsuarioCadastroId",
                table: "LocalArmazenagemModel",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_estoque_LocalArmazenagemId",
                table: "tab_estoque",
                column: "LocalArmazenagemId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_estoque_TipoMaterialId",
                table: "tab_estoque",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_estoque_UsuarioAlteracaoId",
                table: "tab_estoque",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_estoque_UsuarioCadastroId",
                table: "tab_estoque",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_substitutos_MaterialEstoqueId",
                table: "tab_substitutos",
                column: "MaterialEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_substitutos_SubstitutoId",
                table: "tab_substitutos",
                column: "SubstitutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_substitutos_UsuarioAlteracaoId",
                table: "tab_substitutos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_substitutos_UsuarioCadatroId",
                table: "tab_substitutos",
                column: "UsuarioCadatroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_tipo_matetial_UserChangeId",
                table: "tab_tipo_matetial",
                column: "UserChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_tipo_matetial_UserRegisterId",
                table: "tab_tipo_matetial",
                column: "UserRegisterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_substitutos");

            migrationBuilder.DropTable(
                name: "tab_estoque");

            migrationBuilder.DropTable(
                name: "LocalArmazenagemModel");

            migrationBuilder.DropTable(
                name: "tab_tipo_matetial");

            migrationBuilder.DropTable(
                name: "tab_user_auth");
        }
    }
}
