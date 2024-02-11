using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class projeto_refatorado_correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemDeServico_Cliente_ClienteId",
                table: "OrdemDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdemDeServico_PrestadorDeServico_PrestadorId",
                table: "OrdemDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_OrdemDeServico_OrdemServicoId",
                table: "Pagamento");

            migrationBuilder.DropTable(
                name: "ServicoOrdemDeServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdemDeServico",
                table: "OrdemDeServico");

            migrationBuilder.RenameTable(
                name: "OrdemDeServico",
                newName: "OrdemServico");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemDeServico_PrestadorId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemDeServico_ClienteId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdemServico",
                table: "OrdemServico",
                column: "OrdemServicoId");

            migrationBuilder.CreateTable(
                name: "ServicoOrdemServico",
                columns: table => new
                {
                    ServicoOrdemServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoOrdemServico", x => x.ServicoOrdemServicoId);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemServico_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemServico_OrdemServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServico",
                        principalColumn: "OrdemServicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemServico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemServico_EnderecoId",
                table: "ServicoOrdemServico",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemServico_OrdemServicoId",
                table: "ServicoOrdemServico",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemServico_ServicoId",
                table: "ServicoOrdemServico",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Cliente_ClienteId",
                table: "OrdemServico",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorId",
                table: "OrdemServico",
                column: "PrestadorId",
                principalTable: "PrestadorDeServico",
                principalColumn: "PrestadorDeServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_OrdemServico_OrdemServicoId",
                table: "Pagamento",
                column: "OrdemServicoId",
                principalTable: "OrdemServico",
                principalColumn: "OrdemServicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Cliente_ClienteId",
                table: "OrdemServico");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_PrestadorDeServico_PrestadorId",
                table: "OrdemServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_OrdemServico_OrdemServicoId",
                table: "Pagamento");

            migrationBuilder.DropTable(
                name: "ServicoOrdemServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdemServico",
                table: "OrdemServico");

            migrationBuilder.RenameTable(
                name: "OrdemServico",
                newName: "OrdemDeServico");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_PrestadorId",
                table: "OrdemDeServico",
                newName: "IX_OrdemDeServico_PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_ClienteId",
                table: "OrdemDeServico",
                newName: "IX_OrdemDeServico_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdemDeServico",
                table: "OrdemDeServico",
                column: "OrdemServicoId");

            migrationBuilder.CreateTable(
                name: "ServicoOrdemDeServico",
                columns: table => new
                {
                    ServicoOrdemDeServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    OrdemDeServicoId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoOrdemDeServico", x => x.ServicoOrdemDeServicoId);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemDeServico_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemDeServico_OrdemDeServico_OrdemDeServicoId",
                        column: x => x.OrdemDeServicoId,
                        principalTable: "OrdemDeServico",
                        principalColumn: "OrdemServicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoOrdemDeServico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemDeServico_EnderecoId",
                table: "ServicoOrdemDeServico",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemDeServico_OrdemDeServicoId",
                table: "ServicoOrdemDeServico",
                column: "OrdemDeServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdemDeServico_ServicoId",
                table: "ServicoOrdemDeServico",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemDeServico_Cliente_ClienteId",
                table: "OrdemDeServico",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemDeServico_PrestadorDeServico_PrestadorId",
                table: "OrdemDeServico",
                column: "PrestadorId",
                principalTable: "PrestadorDeServico",
                principalColumn: "PrestadorDeServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_OrdemDeServico_OrdemServicoId",
                table: "Pagamento",
                column: "OrdemServicoId",
                principalTable: "OrdemDeServico",
                principalColumn: "OrdemServicoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
