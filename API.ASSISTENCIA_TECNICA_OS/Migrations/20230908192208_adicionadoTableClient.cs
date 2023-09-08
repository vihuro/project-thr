using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoTableClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MaquinaClienteModelId",
                table: "tab_pecaPorMaquina",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tab_client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CodigoRadar = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    NomeContatoClient = table.Column<string>(type: "text", nullable: true),
                    ContatoTelefone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_maquina_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaquinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_maquina_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_maquina_cliente_tab_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tab_client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tab_maquina_cliente_tab_maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "tab_maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_pecaPorMaquina_MaquinaClienteModelId",
                table: "tab_pecaPorMaquina",
                column: "MaquinaClienteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_ClientId",
                table: "tab_maquina_cliente",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_maquina_cliente_MaquinaId",
                table: "tab_maquina_cliente",
                column: "MaquinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_pecaPorMaquina_tab_maquina_cliente_MaquinaClienteModelId",
                table: "tab_pecaPorMaquina",
                column: "MaquinaClienteModelId",
                principalTable: "tab_maquina_cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_pecaPorMaquina_tab_maquina_cliente_MaquinaClienteModelId",
                table: "tab_pecaPorMaquina");

            migrationBuilder.DropTable(
                name: "tab_maquina_cliente");

            migrationBuilder.DropTable(
                name: "tab_client");

            migrationBuilder.DropIndex(
                name: "IX_tab_pecaPorMaquina_MaquinaClienteModelId",
                table: "tab_pecaPorMaquina");

            migrationBuilder.DropColumn(
                name: "MaquinaClienteModelId",
                table: "tab_pecaPorMaquina");
        }
    }
}
