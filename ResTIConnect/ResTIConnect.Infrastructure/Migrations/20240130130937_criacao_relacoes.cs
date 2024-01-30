using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResTIConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class criacao_relacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_enderecos_EnderecoId",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_EnderecoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventoSistemas",
                columns: table => new
                {
                    EventosEventoId = table.Column<int>(type: "int", nullable: false),
                    SistemasSistemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoSistemas", x => new { x.EventosEventoId, x.SistemasSistemaId });
                    table.ForeignKey(
                        name: "FK_EventoSistemas_Sistemas_SistemasSistemaId",
                        column: x => x.SistemasSistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "SistemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoSistemas_eventos_EventosEventoId",
                        column: x => x.EventosEventoId,
                        principalTable: "eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SistemasUsuario",
                columns: table => new
                {
                    SistemasSistemaId = table.Column<int>(type: "int", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemasUsuario", x => new { x.SistemasSistemaId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_SistemasUsuario_Sistemas_SistemasSistemaId",
                        column: x => x.SistemasSistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "SistemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemasUsuario_usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_UsuarioId",
                table: "enderecos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventoSistemas_SistemasSistemaId",
                table: "EventoSistemas",
                column: "SistemasSistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemasUsuario_UsuariosUsuarioId",
                table: "SistemasUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_usuarios_UsuarioId",
                table: "enderecos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_usuarios_UsuarioId",
                table: "enderecos");

            migrationBuilder.DropTable(
                name: "EventoSistemas");

            migrationBuilder.DropTable(
                name: "SistemasUsuario");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_UsuarioId",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "enderecos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_EnderecoId",
                table: "usuarios",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_enderecos_EnderecoId",
                table: "usuarios",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
