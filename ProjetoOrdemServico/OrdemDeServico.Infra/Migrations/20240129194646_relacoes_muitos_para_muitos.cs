using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class relacoes_muitos_para_muitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdemDeServicoId",
                table: "ServicoOrdemDeServico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "ServicoOrdemDeServico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precos = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.ServicoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemDeServico_OrdemDeServicoId",
                table: "ServicoOrdemDeServico",
                column: "OrdemDeServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemDeServico_ServicoId",
                table: "ServicoOrdemDeServico",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoOrdemDeServico_OrdemDeServico_OrdemDeServicoId",
                table: "ServicoOrdemDeServico",
                column: "OrdemDeServicoId",
                principalTable: "OrdemDeServico",
                principalColumn: "OrdemServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoOrdemDeServico_Servico_ServicoId",
                table: "ServicoOrdemDeServico",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicoOrdemDeServico_OrdemDeServico_OrdemDeServicoId",
                table: "ServicoOrdemDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicoOrdemDeServico_Servico_ServicoId",
                table: "ServicoOrdemDeServico");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_ServicoOrdemDeServico_OrdemDeServicoId",
                table: "ServicoOrdemDeServico");

            migrationBuilder.DropIndex(
                name: "IX_ServicoOrdemDeServico_ServicoId",
                table: "ServicoOrdemDeServico");

            migrationBuilder.DropColumn(
                name: "OrdemDeServicoId",
                table: "ServicoOrdemDeServico");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "ServicoOrdemDeServico");
        }
    }
}
