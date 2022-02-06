using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utad.Lab.CodingFilm.Areas.Admin.Models;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.WebApp.Models;

namespace Utad.Lab.CodingFilm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Renomeamento das tabelas Identity 
            builder.Entity<IdentityUser>().ToTable("Utilizadores"); //AspNetUsers
            builder.Entity<IdentityRole>().ToTable("Grupo_de_Utilizadores"); //AspNetRoles
            builder.Entity<IdentityUserRole<string>>().ToTable("Utilizador_Grupo_de_Utilizadores"); //AspNetUserRole
        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Filmes_Utilizador> Filmes_Utilizador {get; set;}
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Sessão> Sessão { get; set; }
        public DbSet<Categorias_Utilizador> Categorias_Utilizador { get; set; }
        public DbSet<Cria_Utilizadores> Cria_Utilizadores { get; set; }
        public DbSet<Salas_Utilizador> Salas_Utilizador { get; set; }
        public DbSet<Sessões_Utilizador> Sessões_Utilizador { get; set; }
        public DbSet<CategoriasFavoritas_Utilizador> CategoriasFavoritas_Utilizador { get; set; }
        public DbSet<CategoriasFavoritas> CategoriasFavoritas { get; set; }
    }
}
