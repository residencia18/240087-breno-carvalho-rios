using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechAdvocacia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mudancas_caso_juridico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ChanceSucesso",
                table: "CasosJuridicos",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChanceSucesso",
                table: "CasosJuridicos");
        }
    }
}
