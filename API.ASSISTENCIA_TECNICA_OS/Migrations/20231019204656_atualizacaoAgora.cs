using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoAgora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_diarioOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_diarioOrcamento");

            migrationBuilder.DropColumn(
                name: "NumeroOrcamentoId",
                table: "tab_diarioOrcamento");

            migrationBuilder.AlterColumn<int>(
                name: "OrcamentoId",
                table: "tab_diarioOrcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_diarioOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_diarioOrcamento",
                column: "OrcamentoId",
                principalTable: "tab_orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_diarioOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_diarioOrcamento");

            migrationBuilder.AlterColumn<int>(
                name: "OrcamentoId",
                table: "tab_diarioOrcamento",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "NumeroOrcamentoId",
                table: "tab_diarioOrcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_diarioOrcamento_tab_orcamento_OrcamentoId",
                table: "tab_diarioOrcamento",
                column: "OrcamentoId",
                principalTable: "tab_orcamento",
                principalColumn: "Id");
        }
    }
}
