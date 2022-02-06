using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class updatetableCategorias_Utilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Utilizador_Filme_CategoriaID",
                table: "Categorias_Utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Utilizador_Categoria_CategoriaID",
                table: "Categorias_Utilizador",
                column: "CategoriaID",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Utilizador_Categoria_CategoriaID",
                table: "Categorias_Utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Utilizador_Filme_CategoriaID",
                table: "Categorias_Utilizador",
                column: "CategoriaID",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
