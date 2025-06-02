using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class RefresBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoId",
                table: "Vendas",
                newName: "FormaPagamentoid");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_FormaPagamentoId",
                table: "Vendas",
                newName: "IX_Vendas_FormaPagamentoid");

            migrationBuilder.AddColumn<int>(
                name: "idFormaPagamento",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEvento",
                table: "eventos",
                type: "datetime2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "clientes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "clientes",
                type: "datetime2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoid",
                table: "Vendas",
                column: "FormaPagamentoid",
                principalTable: "formasPagamento",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoid",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "idFormaPagamento",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoid",
                table: "Vendas",
                newName: "FormaPagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_FormaPagamentoid",
                table: "Vendas",
                newName: "IX_Vendas_FormaPagamentoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEvento",
                table: "eventos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_formasPagamento_FormaPagamentoId",
                table: "Vendas",
                column: "FormaPagamentoId",
                principalTable: "formasPagamento",
                principalColumn: "id");
        }
    }
}
