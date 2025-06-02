using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class DeleteColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_eventos_Eventoid",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoid",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_FormaPagamentoid",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_ItensVenda_Eventoid",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoid",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Eventoid",
                table: "ItensVenda");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idFormaPagamento",
                table: "Vendas",
                column: "idFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_idEvento",
                table: "ItensVenda",
                column: "idEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_ItemVenda",
                table: "ItensVenda",
                column: "idEvento",
                principalTable: "eventos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_formasPagamento_idFormaPagamento",
                table: "Vendas",
                column: "idFormaPagamento",
                principalTable: "formasPagamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_ItemVenda",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_formasPagamento_idFormaPagamento",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idFormaPagamento",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_ItensVenda_idEvento",
                table: "ItensVenda");

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoid",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Eventoid",
                table: "ItensVenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaPagamentoid",
                table: "Vendas",
                column: "FormaPagamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_Eventoid",
                table: "ItensVenda",
                column: "Eventoid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_eventos_Eventoid",
                table: "ItensVenda",
                column: "Eventoid",
                principalTable: "eventos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoid",
                table: "Vendas",
                column: "FormaPagamentoid",
                principalTable: "formasPagamento",
                principalColumn: "id");
        }
    }
}
