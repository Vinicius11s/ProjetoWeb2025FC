using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JantaCompleta",
                table: "servicos",
                newName: "ValorServico");

            migrationBuilder.RenameColumn(
                name: "ChurrascoTradicional",
                table: "servicos",
                newName: "QtdeProfissionais");

            migrationBuilder.RenameColumn(
                name: "ChurrascoAmericano",
                table: "servicos",
                newName: "NomeServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorServico",
                table: "servicos",
                newName: "JantaCompleta");

            migrationBuilder.RenameColumn(
                name: "QtdeProfissionais",
                table: "servicos",
                newName: "ChurrascoTradicional");

            migrationBuilder.RenameColumn(
                name: "NomeServico",
                table: "servicos",
                newName: "ChurrascoAmericano");
        }
    }
}
