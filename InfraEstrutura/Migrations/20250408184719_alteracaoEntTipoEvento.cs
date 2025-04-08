using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoEntTipoEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aniversario",
                table: "tiposEventos");

            migrationBuilder.DropColumn(
                name: "AniversarioInfantil",
                table: "tiposEventos");

            migrationBuilder.DropColumn(
                name: "Casamento",
                table: "tiposEventos");

            migrationBuilder.RenameColumn(
                name: "Corporativo",
                table: "tiposEventos",
                newName: "Descricao");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "tiposEventos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "tiposEventos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "tiposEventos",
                newName: "Corporativo");

            migrationBuilder.AddColumn<string>(
                name: "Aniversario",
                table: "tiposEventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AniversarioInfantil",
                table: "tiposEventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Casamento",
                table: "tiposEventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
