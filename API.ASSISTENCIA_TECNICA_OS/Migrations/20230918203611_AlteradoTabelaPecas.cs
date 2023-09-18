using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoTabelaPecas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tab_pecas",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRadar",
                table: "tab_pecas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "tab_pecas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCadastro",
                table: "tab_pecas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioAlteracaoId",
                table: "tab_pecas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCadastroId",
                table: "tab_pecas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_UsuarioAlteracaoId",
                table: "tab_pecas",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecas_UsuarioCadastroId",
                table: "tab_pecas",
                column: "UsuarioCadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_pecas_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_pecas",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_pecas_tab_user_auth_UsuarioCadastroId",
                table: "tab_pecas",
                column: "UsuarioCadastroId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_pecas_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_pecas_tab_user_auth_UsuarioCadastroId",
                table: "tab_pecas");

            migrationBuilder.DropIndex(
                name: "IX_tab_pecas_UsuarioAlteracaoId",
                table: "tab_pecas");

            migrationBuilder.DropIndex(
                name: "IX_tab_pecas_UsuarioCadastroId",
                table: "tab_pecas");

            migrationBuilder.DropColumn(
                name: "CodigoRadar",
                table: "tab_pecas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "tab_pecas");

            migrationBuilder.DropColumn(
                name: "DataHoraCadastro",
                table: "tab_pecas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "tab_pecas");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastroId",
                table: "tab_pecas");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "tab_pecas",
                newName: "Nome");
        }
    }
}
