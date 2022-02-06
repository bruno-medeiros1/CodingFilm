using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class Atualizaçãoatributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessões_Utilizador_Sala_SessãoID",
                table: "Sessões_Utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessões_Utilizador_Sessão_SessãoID",
                table: "Sessões_Utilizador",
                column: "SessãoID",
                principalTable: "Sessão",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessões_Utilizador_Sessão_SessãoID",
                table: "Sessões_Utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessões_Utilizador_Sala_SessãoID",
                table: "Sessões_Utilizador",
                column: "SessãoID",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
