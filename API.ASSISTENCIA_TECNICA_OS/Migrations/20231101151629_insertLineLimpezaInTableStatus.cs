using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class insertLineLimpezaInTableStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('1','ORÇAMENTO PENDENTE')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('2','AGUARDANDO ORÇAMENTO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('3','EM NEGOCIAÇÃO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('4','ORÇAMENTO APROVADO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('5','ORÇAMENTO RECUSADO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('6','AGUARDANDO MANUTENÇÃO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('7','MANUTENÇÃO INICIADA')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('8','MANUNTENÇÃO FINALIZADA')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('9','LIMPEZA INICIADA')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('10','LIMPEZA FINALIZADA')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tab_status");
        }
    }
}
