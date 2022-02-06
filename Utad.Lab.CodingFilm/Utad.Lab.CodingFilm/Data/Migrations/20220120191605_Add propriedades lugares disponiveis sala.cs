using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class Addpropriedadeslugaresdisponiveissala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lugaresDisponiveis",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lugaresDisponiveis",
                table: "Sala");
        }
    }
}
