using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AdiconandoDuasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusOrcamentoModel_StatusModel_StatusId",
                table: "StatusOrcamentoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusOrcamentoModel_tab_orcamento_OrcamentoId",
                table: "StatusOrcamentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusOrcamentoModel",
                table: "StatusOrcamentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusModel",
                table: "StatusModel");

            migrationBuilder.RenameTable(
                name: "StatusOrcamentoModel",
                newName: "tab_statusOrcamento");

            migrationBuilder.RenameTable(
                name: "StatusModel",
                newName: "tab_status");

            migrationBuilder.RenameIndex(
                name: "IX_StatusOrcamentoModel_StatusId",
                table: "tab_statusOrcamento",
                newName: "IX_tab_statusOrcamento_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusOrcamentoModel_OrcamentoId",
                table: "tab_statusOrcamento",
                newName: "IX_tab_statusOrcamento_OrcamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tab_statusOrcamento",
                table: "tab_statusOrcamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tab_status",
                table: "tab_status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_statusOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_statusOrcamento",
                column: "OrcamentoId",
                principalTable: "tab_orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_statusOrcamento_tab_status_StatusId",
                table: "tab_statusOrcamento",
                column: "StatusId",
                principalTable: "tab_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_statusOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_statusOrcamento_tab_status_StatusId",
                table: "tab_statusOrcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tab_statusOrcamento",
                table: "tab_statusOrcamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tab_status",
                table: "tab_status");

            migrationBuilder.RenameTable(
                name: "tab_statusOrcamento",
                newName: "StatusOrcamentoModel");

            migrationBuilder.RenameTable(
                name: "tab_status",
                newName: "StatusModel");

            migrationBuilder.RenameIndex(
                name: "IX_tab_statusOrcamento_StatusId",
                table: "StatusOrcamentoModel",
                newName: "IX_StatusOrcamentoModel_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_tab_statusOrcamento_OrcamentoId",
                table: "StatusOrcamentoModel",
                newName: "IX_StatusOrcamentoModel_OrcamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusOrcamentoModel",
                table: "StatusOrcamentoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusModel",
                table: "StatusModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusOrcamentoModel_StatusModel_StatusId",
                table: "StatusOrcamentoModel",
                column: "StatusId",
                principalTable: "StatusModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusOrcamentoModel_tab_orcamento_OrcamentoId",
                table: "StatusOrcamentoModel",
                column: "OrcamentoId",
                principalTable: "tab_orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
