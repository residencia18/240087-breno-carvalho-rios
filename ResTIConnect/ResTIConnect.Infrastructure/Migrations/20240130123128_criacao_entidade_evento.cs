using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResTIConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class criacao_entidade_evento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "usuarios",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "perfis",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "logs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "enderecos",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conteudo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHoraOcorrencia = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.EventoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "usuarios",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "perfis",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "logs",
                newName: "CretedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "enderecos",
                newName: "CretedAt");
        }
    }
}
