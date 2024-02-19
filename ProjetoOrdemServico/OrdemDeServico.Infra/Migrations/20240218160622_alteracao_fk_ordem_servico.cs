using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alteracao_fk_ordem_servico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorId",
                table: "OrdemServico");

            migrationBuilder.RenameColumn(
                name: "PrestadorId",
                table: "OrdemServico",
                newName: "PrestadorDeServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_PrestadorId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_PrestadorDeServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorDeServicoId",
                table: "OrdemServico",
                column: "PrestadorDeServicoId",
                principalTable: "PrestadorDeServico",
                principalColumn: "PrestadorDeServicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorDeServicoId",
                table: "OrdemServico");

            migrationBuilder.RenameColumn(
                name: "PrestadorDeServicoId",
                table: "OrdemServico",
                newName: "PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_PrestadorDeServicoId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorId",
                table: "OrdemServico",
                column: "PrestadorId",
                principalTable: "PrestadorDeServico",
                principalColumn: "PrestadorDeServicoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
