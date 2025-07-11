using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedConfiguracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfiguracaoEstacionamentos",
                columns: new[] { "Id", "ValorInicial", "ValorMensalidade", "ValorPorHora" },
                values: new object[] { 1, 0m, 0m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfiguracaoEstacionamentos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
