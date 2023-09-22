using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class VamosVerSeVai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_orcamento_tab_maquina_cliente_MaquinaClienteId",
                table: "tab_orcamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaquinaClienteId",
                table: "tab_orcamento",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "MaquinaId",
                table: "tab_orcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_orcamento_MaquinaId",
                table: "tab_orcamento",
                column: "MaquinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_orcamento_tab_maquina_MaquinaId",
                table: "tab_orcamento",
                column: "MaquinaId",
                principalTable: "tab_maquina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_orcamento_tab_maquina_cliente_MaquinaClienteId",
                table: "tab_orcamento",
                column: "MaquinaClienteId",
                principalTable: "tab_maquina_cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_orcamento_tab_maquina_MaquinaId",
                table: "tab_orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_orcamento_tab_maquina_cliente_MaquinaClienteId",
                table: "tab_orcamento");

            migrationBuilder.DropIndex(
                name: "IX_tab_orcamento_MaquinaId",
                table: "tab_orcamento");

            migrationBuilder.DropColumn(
                name: "MaquinaId",
                table: "tab_orcamento");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaquinaClienteId",
                table: "tab_orcamento",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_orcamento_tab_maquina_cliente_MaquinaClienteId",
                table: "tab_orcamento",
                column: "MaquinaClienteId",
                principalTable: "tab_maquina_cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
