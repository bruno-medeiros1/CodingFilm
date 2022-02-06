using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class AdiçãopropriedadeHorarioemSessão : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Horário",
                table: "Sessão",
                type: "time(1)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horário",
                table: "Sessão");
        }
    }
}
