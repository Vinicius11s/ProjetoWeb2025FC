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
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formasPagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPorPessoa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuracaoHoras = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposEventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_formasPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "formasPagamento",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTipoEvento = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadePessoas = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                name: "ItensVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVenda = table.Column<int>(type: "int", nullable: false),
                    idEvento = table.Column<int>(type: "int", nullable: false),
                    Eventoid = table.Column<int>(type: "int", nullable: true),
                    idServico = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Servicoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVenda_eventos_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "eventos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ItensVenda_servicos_Servicoid",
                        column: x => x.Servicoid,
                        principalTable: "servicos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Servico_ItemVenda",
                        column: x => x.idServico,
                        principalTable: "servicos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Venda_ItemVenda",
                        column: x => x.idVenda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
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
                name: "IX_ItensVenda_Eventoid",
                table: "ItensVenda",
                column: "Eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_idServico",
                table: "ItensVenda",
                column: "idServico");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_idVenda",
                table: "ItensVenda",
                column: "idVenda");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_Servicoid",
                table: "ItensVenda",
                column: "Servicoid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaPagamentoId",
                table: "Vendas",
                column: "FormaPagamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "tiposEventos");

            migrationBuilder.DropTable(
                name: "formasPagamento");
        }
    }
}
