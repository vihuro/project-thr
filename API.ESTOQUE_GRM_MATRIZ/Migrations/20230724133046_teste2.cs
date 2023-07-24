using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "tab_local_armazenagem");

            migrationBuilder.RenameIndex(
                name: "IX_Local_UsuarioCadastroId",
                table: "tab_local_armazenagem",
                newName: "IX_tab_local_armazenagem_UsuarioCadastroId");

            migrationBuilder.RenameIndex(
                name: "IX_Local_UsuarioAlteracaoId",
                table: "tab_local_armazenagem",
                newName: "IX_tab_local_armazenagem_UsuarioAlteracaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tab_local_armazenagem",
                table: "tab_local_armazenagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_estoque_tab_local_armazenagem_LocalArmazenagemId",
                table: "tab_estoque",
                column: "LocalArmazenagemId",
                principalTable: "tab_local_armazenagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_local_armazenagem_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_local_armazenagem",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_local_armazenagem_tab_user_auth_UsuarioCadastroId",
                table: "tab_local_armazenagem",
                column: "UsuarioCadastroId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_estoque_tab_local_armazenagem_LocalArmazenagemId",
                table: "tab_estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_local_armazenagem_tab_user_auth_UsuarioAlteracaoId",
                table: "tab_local_armazenagem");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_local_armazenagem_tab_user_auth_UsuarioCadastroId",
                table: "tab_local_armazenagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tab_local_armazenagem",
                table: "tab_local_armazenagem");

            migrationBuilder.RenameTable(
                name: "tab_local_armazenagem",
                newName: "Local");

            migrationBuilder.RenameIndex(
                name: "IX_tab_local_armazenagem_UsuarioCadastroId",
                table: "Local",
                newName: "IX_Local_UsuarioCadastroId");

            migrationBuilder.RenameIndex(
                name: "IX_tab_local_armazenagem_UsuarioAlteracaoId",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
