using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class testePopularBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('ORÇAMENTO PENDENTE')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('AGUARDANDO ORÇAMENTO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('EM NEGOCIAÇÃO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('ORÇAMENTO APROVADO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('ORÇAMENTO RECUSADO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('GUARDANDO MANUTENÇÃO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('MANUTENÇÃO INICIADA')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Status"") VALUES ('MANUNTENÇÃO FINALIZADA')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tab_status");
        }
    }
}
