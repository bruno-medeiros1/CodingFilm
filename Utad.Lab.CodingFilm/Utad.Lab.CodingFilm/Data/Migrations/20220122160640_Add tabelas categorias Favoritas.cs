using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AddtabelascategoriasFavoritas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasFavoritas_Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasFavoritas_Utilizador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriasFavoritas_Utilizador_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasFavoritas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriasFavoritas_UtilizadorID = table.Column<int>(type: "int", nullable: true),
                    CategoriaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasFavoritas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriasFavoritas_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriasFavoritas_CategoriasFavoritas_Utilizador_CategoriasFavoritas_UtilizadorID",
                        column: x => x.CategoriasFavoritas_UtilizadorID,
                        principalTable: "CategoriasFavoritas_Utilizador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasFavoritas_CategoriaID",
                table: "CategoriasFavoritas",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasFavoritas_CategoriasFavoritas_UtilizadorID",
                table: "CategoriasFavoritas",
                column: "CategoriasFavoritas_UtilizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasFavoritas_Utilizador_UtilizadorID",
                table: "CategoriasFavoritas_Utilizador",
                column: "UtilizadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasFavoritas");

            migrationBuilder.DropTable(
                name: "CategoriasFavoritas_Utilizador");
        }
    }
}
