using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AddTabelaCria_Utilizadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cria_Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utilizador1ID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Utilizador2ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cria_Utilizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cria_Utilizadores_Utilizadores_Utilizador1ID",
                        column: x => x.Utilizador1ID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cria_Utilizadores_Utilizadores_Utilizador2ID",
                        column: x => x.Utilizador2ID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cria_Utilizadores_Utilizador1ID",
                table: "Cria_Utilizadores",
                column: "Utilizador1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cria_Utilizadores_Utilizador2ID",
                table: "Cria_Utilizadores",
                column: "Utilizador2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cria_Utilizadores");
        }
    }
}
