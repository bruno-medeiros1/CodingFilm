using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    /*Tabela que vai guardar ID do utilizador e ID da lista de categorias favorita do utilizador*/
    public class CategoriasFavoritas_Utilizador
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("UtilizadorID")]
        public virtual Utilizador Utilizador { get; set; }
    }
}
