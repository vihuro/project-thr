using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioAlteracaoId",
                table: "Local",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioAlteracaoId",
                table: "Local",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_tab_user_auth_UsuarioAlteracaoId",
                table: "Local",
                column: "UsuarioAlteracaoId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");
        }
    }
}
