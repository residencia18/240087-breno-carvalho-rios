using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class relacoes_um_para_muitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "ServicoOrdemDeServico",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "PrestadorDeServico",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "Endereco",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "Cliente",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "OrdemDeServico",
                columns: table => new
                {
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataDeEmissao = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServico", x => x.OrdemServicoId);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_PrestadorDeServico_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "PrestadorDeServico",
                        principalColumn: "PrestadorDeServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<float>(type: "float", nullable: false),
                    DataPagamento = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Pagamento_OrdemDeServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemDeServico",
                        principalColumn: "OrdemServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_ClienteId",
                table: "OrdemDeServico",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_PrestadorId",
                table: "OrdemDeServico",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ClienteId",
                table: "Pagamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_OrdemServicoId",
                table: "Pagamento",
                column: "OrdemServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "OrdemDeServico");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ServicoOrdemDeServico",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PrestadorDeServico",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Endereco",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Cliente",
                newName: "CretedAt");
        }
    }
}
