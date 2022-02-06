using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Utad.Lab.CodingFilm.Data.Migrations
{
    public partial class Addpropriedadesfilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sessão",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Horário",
                table: "Sessão",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(1)");

            migrationBuilder.AddColumn<string>(
                name: "pais",
                table: "Filme",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "trailerLink",
                table: "Filme",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pais",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "trailerLink",
                table: "Filme");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sessão",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Horário",
                table: "Sessão",
                type: "time(1)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
