using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoMVC.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableRegistroEstacionamentoAddValor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "RegistroEstacionamento",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "RegistroEstacionamento");
        }
    }
}
