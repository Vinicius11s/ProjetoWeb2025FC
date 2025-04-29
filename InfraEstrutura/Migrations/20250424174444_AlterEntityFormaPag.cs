using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class AlterEntityFormaPag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credito",
                table: "formasPagamento");

            migrationBuilder.DropColumn(
                name: "Debito",
                table: "formasPagamento");

            migrationBuilder.DropColumn(
                name: "Dinheiro",
                table: "formasPagamento");

            migrationBuilder.DropColumn(
                name: "Pix",
                table: "formasPagamento");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "formasPagamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "formasPagamento");

            migrationBuilder.AddColumn<int>(
                name: "Credito",
                table: "formasPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Debito",
                table: "formasPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dinheiro",
                table: "formasPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pix",
                table: "formasPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
