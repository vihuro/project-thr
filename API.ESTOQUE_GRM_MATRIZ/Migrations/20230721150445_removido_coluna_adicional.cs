using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    /// <inheritdoc />
    public partial class removido_coluna_adicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tab_user_auth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "tab_user_auth",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
