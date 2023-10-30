using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class changeForAddColumnUserInTablePartsInBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "tab_pecasMaquinaEOrcamento",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCadastro",
                table: "tab_pecasMaquinaEOrcamento",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "UsuarioCadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_pecasMaquinaEOrcamento_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_pecasMaquinaEOrcamento_tab_user_auth_UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento",
                column: "UsuarioCadastroId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_pecasMaquinaEOrcamento_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_pecasMaquinaEOrcamento_tab_user_auth_UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_pecasMaquinaEOrcamento_UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropColumn(
                name: "DataHoraCadastro",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "tab_pecasMaquinaEOrcamento");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastroId",
                table: "tab_pecasMaquinaEOrcamento");
        }
    }
}
