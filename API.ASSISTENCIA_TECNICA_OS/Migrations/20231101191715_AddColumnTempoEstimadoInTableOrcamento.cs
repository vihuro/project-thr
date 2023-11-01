using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnTempoEstimadoInTableOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TempoEstimadoManutencao",
                table: "tab_orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempoEstimadoOrcamento",
                table: "tab_orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoEstimadoManutencao",
                table: "tab_orcamento");

            migrationBuilder.DropColumn(
                name: "TempoEstimadoOrcamento",
                table: "tab_orcamento");
        }
    }
}
