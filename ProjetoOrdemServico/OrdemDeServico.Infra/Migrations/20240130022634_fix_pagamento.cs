using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fix_pagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Cliente_ClienteId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_ClienteId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pagamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ClienteId",
                table: "Pagamento",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Cliente_ClienteId",
                table: "Pagamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }
    }
}
