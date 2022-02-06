using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AdiçãoSalaIDnatabelaSessão : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Sessão_SessãoID",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_SessãoID",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "SessãoID",
                table: "Sala");

            migrationBuilder.AddColumn<int>(
                name: "SalaID",
                table: "Sessão",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessão_SalaID",
                table: "Sessão",
                column: "SalaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessão_Sala_SalaID",
                table: "Sessão",
                column: "SalaID",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessão_Sala_SalaID",
                table: "Sessão");

            migrationBuilder.DropIndex(
                name: "IX_Sessão_SalaID",
                table: "Sessão");

            migrationBuilder.DropColumn(
                name: "SalaID",
                table: "Sessão");

            migrationBuilder.AddColumn<int>(
                name: "SessãoID",
                table: "Sala",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_SessãoID",
                table: "Sala",
                column: "SessãoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Sessão_SessãoID",
                table: "Sala",
                column: "SessãoID",
                principalTable: "Sessão",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
