using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AdiçãodeTabelasparaFilmes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaID = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descrição = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Realizador = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Duração = table.Column<TimeSpan>(type: "time(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filmes_Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmeID = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes_Utilizador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Utilizador_Filme_FilmeID",
                        column: x => x.FilmeID,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filmes_Utilizador_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_CategoriaID",
                table: "Filme",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_Utilizador_FilmeID",
                table: "Filmes_Utilizador",
                column: "FilmeID");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_Utilizador_UtilizadorID",
                table: "Filmes_Utilizador",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes_Utilizador");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
