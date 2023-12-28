using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    /// <inheritdoc />
    public partial class PopularBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('1','ORÇAMENTO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('2','NEGOCIAÇÃO')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('3','SEPARAÇÃO DE PEÇAS')");
            migrationBuilder.Sql(@"INSERT INTO tab_status (""Id"",""Status"") VALUES ('4','MANUTENÇÃO')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tab_status");
        }
    }
}
