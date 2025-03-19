using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class InitialBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "formasPagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Credito = table.Column<int>(type: "int", nullable: false),
                    Debito = table.Column<int>(type: "int", nullable: false),
                    Dinheiro = table.Column<int>(type: "int", nullable: false),
                    Pix = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formasPagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChurrascoTradicional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChurrascoAmericano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JantaCompleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cardapio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tiposEventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aniversario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AniversarioInfantil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Casamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corporativo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposEventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdeAdultos = table.Column<int>(type: "int", nullable: false),
                    QtdeCriancas = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<int>(type: "int", precision: 8, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idTipoEvento = table.Column<int>(type: "int", nullable: false),
                    idFormaPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Eventos",
                        column: x => x.idCliente,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FormaPagamento_Evento",
                        column: x => x.idFormaPagamento,
                        principalTable: "formasPagamento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TipoEvento_Evento",
                        column: x => x.idTipoEvento,
                        principalTable: "tiposEventos",
                        principalColumn: "id");
                });

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
                name: "IX_eventos_idCliente",
                table: "eventos",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_eventos_idFormaPagamento",
                table: "eventos",
                column: "idFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_eventos_idTipoEvento",
                table: "eventos",
                column: "idTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_tiposEventosServicos_ServicoId",
                table: "tiposEventosServicos",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "tiposEventosServicos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "formasPagamento");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "tiposEventos");
        }
    }
}
