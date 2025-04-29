using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class AltPropTipoEventoServ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tiposEventosServicos");

            migrationBuilder.DropColumn(
                name: "QtdeAdultos",
                table: "eventos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "eventos");

            migrationBuilder.RenameColumn(
                name: "QtdeCriancas",
                table: "eventos",
                newName: "QtdePessoas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdePessoas",
                table: "eventos",
                newName: "QtdeCriancas");

            migrationBuilder.AddColumn<int>(
                name: "QtdeAdultos",
                table: "eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorTotal",
                table: "eventos",
                type: "int",
                precision: 8,
                scale: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tiposEventosServicos",
                columns: table => new
                {
                    TipoEventoId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposEventosServicos", x => new { x.TipoEventoId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_tiposEventosServicos_servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "servicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tiposEventosServicos_tiposEventos_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "tiposEventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tiposEventosServicos_ServicoId",
                table: "tiposEventosServicos",
                column: "ServicoId");
        }
    }
}
