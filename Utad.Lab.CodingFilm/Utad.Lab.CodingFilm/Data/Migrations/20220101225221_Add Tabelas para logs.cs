using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AddTabelasparalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salas_Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas_Utilizador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salas_Utilizador_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salas_Utilizador_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessões_Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessãoID = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessões_Utilizador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessões_Utilizador_Sala_SessãoID",
                        column: x => x.SessãoID,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessões_Utilizador_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salas_Utilizador_SalaID",
                table: "Salas_Utilizador",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_Utilizador_UtilizadorID",
                table: "Salas_Utilizador",
                column: "UtilizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessões_Utilizador_SessãoID",
                table: "Sessões_Utilizador",
                column: "SessãoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessões_Utilizador_UtilizadorID",
                table: "Sessões_Utilizador",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salas_Utilizador");

            migrationBuilder.DropTable(
                name: "Sessões_Utilizador");
        }
    }
}
