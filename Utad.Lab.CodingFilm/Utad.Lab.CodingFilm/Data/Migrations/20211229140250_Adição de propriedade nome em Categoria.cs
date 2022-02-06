using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AdiçãodepropriedadenomeemCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Categoria",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Categoria");
        }
    }
}
