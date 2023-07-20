using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AUTH.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Apelido = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_typeClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    DataHoraCadatro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_typeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_typeClaims_tab_user_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_typeClaims_tab_user_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_claimsForUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeClaimsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserClaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserRegisterId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserChangeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_claimsForUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_claimsForUser_tab_typeClaims_TypeClaimsId",
                        column: x => x.TypeClaimsId,
                        principalTable: "tab_typeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_claimsForUser_tab_user_UserChangeId",
                        column: x => x.UserChangeId,
                        principalTable: "tab_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_claimsForUser_tab_user_UserClaimId",
                        column: x => x.UserClaimId,
                        principalTable: "tab_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_claimsForUser_tab_user_UserRegisterId",
                        column: x => x.UserRegisterId,
                        principalTable: "tab_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_claimsForUser_TypeClaimsId",
                table: "tab_claimsForUser",
                column: "TypeClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_claimsForUser_UserChangeId",
                table: "tab_claimsForUser",
                column: "UserChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_claimsForUser_UserClaimId",
                table: "tab_claimsForUser",
                column: "UserClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_claimsForUser_UserRegisterId",
                table: "tab_claimsForUser",
                column: "UserRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_typeClaims_UsuarioAlteracaoId",
                table: "tab_typeClaims",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_typeClaims_UsuarioCadastroId",
                table: "tab_typeClaims",
                column: "UsuarioCadastroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_claimsForUser");

            migrationBuilder.DropTable(
                name: "tab_typeClaims");

            migrationBuilder.DropTable(
                name: "tab_user");
        }
    }
}
