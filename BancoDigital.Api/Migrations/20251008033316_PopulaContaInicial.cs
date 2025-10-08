using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoDigital.Api.Migrations
{
    /// <inheritdoc />
    public partial class PopulaContaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CONTAS (CONTA, SALDO) VALUES (54321, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CONTAS");
        }
    }
}
