using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loterias.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoJogo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoJogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoJogoId = table.Column<Guid>(nullable: false),
                    DataConcurso = table.Column<DateTime>(nullable: false),
                    NumeroConcurso = table.Column<int>(nullable: false),
                    DezenasSorteadas = table.Column<string>(nullable: true),
                    PremioAcumulado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogo_TipoJogo_TipoJogoId",
                        column: x => x.TipoJogoId,
                        principalTable: "TipoJogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_TipoJogoId",
                table: "Jogo",
                column: "TipoJogoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropTable(
                name: "TipoJogo");
        }
    }
}
