using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioAlteracaoId",
                table: "LocalArmazenagemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioCadastroId",
                table: "LocalArmazenagemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_estoque_LocalArmazenagemModel_LocalArmazenagemId",
                table: "tab_estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalArmazenagemModel",
                table: "LocalArmazenagemModel");

            migrationBuilder.RenameTable(
                name: "LocalArmazenagemModel",
                newName: "Local");

            migrationBuilder.RenameIndex(
                name: "IX_LocalArmazenagemModel_UsuarioCadastroId",
                table: "Local",
                newName: "IX_Local_UsuarioCadastroId");

            migrationBuilder.RenameIndex(
                name: "IX_LocalArmazenagemModel_UsuarioAlteracaoId",
                table: "Local",
                newName: "IX_Local_UsuarioAlteracaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "Local",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioCadastroId",
                table: "Local",
                column: "UsuarioCadastroId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_estoque_Local_LocalArmazenagemId",
                table: "tab_estoque",
                column: "LocalArmazenagemId",
                principalTable: "Local",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local");

            migrationBuilder.DropForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioCadastroId",
                table: "Local");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_estoque_Local_LocalArmazenagemId",
                table: "tab_estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "LocalArmazenagemModel");

            migrationBuilder.RenameIndex(
                name: "IX_Local_UsuarioCadastroId",
                table: "LocalArmazenagemModel",
                newName: "IX_LocalArmazenagemModel_UsuarioCadastroId");

            migrationBuilder.RenameIndex(
                name: "IX_Local_UsuarioAlteracaoId",
                table: "LocalArmazenagemModel",
                newName: "IX_LocalArmazenagemModel_UsuarioAlteracaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalArmazenagemModel",
                table: "LocalArmazenagemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioAlteracaoId",
                table: "LocalArmazenagemModel",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalArmazenagemModel_tab_user_auth_UsuarioCadastroId",
                table: "LocalArmazenagemModel",
                column: "UsuarioCadastroId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_estoque_LocalArmazenagemModel_LocalArmazenagemId",
                table: "tab_estoque",
                column: "LocalArmazenagemId",
                principalTable: "LocalArmazenagemModel",
                principalColumn: "Id");
        }
    }
}
