using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiDoClienteInMaquinaClienteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_maquina_cliente_tab_client_ClientId",
                table: "tab_maquina_cliente");

            migrationBuilder.DropIndex(
                name: "IX_tab_maquina_cliente_ClientId",
                table: "tab_maquina_cliente");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "tab_maquina_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_ClienteId",
                table: "tab_maquina_cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_maquina_cliente_tab_client_ClienteId",
                table: "tab_maquina_cliente",
                column: "ClienteId",
                principalTable: "tab_client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_maquina_cliente_tab_client_ClienteId",
                table: "tab_maquina_cliente");

            migrationBuilder.DropIndex(
                name: "IX_tab_maquina_cliente_ClienteId",
                table: "tab_maquina_cliente");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "tab_maquina_cliente",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_ClientId",
                table: "tab_maquina_cliente",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_maquina_cliente_tab_client_ClientId",
                table: "tab_maquina_cliente",
                column: "ClientId",
                principalTable: "tab_client",
                principalColumn: "Id");
        }
    }
}
