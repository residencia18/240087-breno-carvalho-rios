using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.Banco.Pessoa.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    DataNascimento = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Uf = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPessoa",
                table: "Endereco",
                column: "IdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
