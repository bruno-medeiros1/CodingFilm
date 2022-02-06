using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AddTableCategorias_Utilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias_Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaID = table.Column<int>(type: "int", nullable: true),
                    UtilizadorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Utilizador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Utilizador_Filme_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categorias_Utilizador_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Utilizador_CategoriaID",
                table: "Categorias_Utilizador",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Utilizador_UtilizadorID",
                table: "Categorias_Utilizador",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias_Utilizador");
        }
    }
}
