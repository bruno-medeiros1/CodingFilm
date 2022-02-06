using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    /* Classe responsável por nos dizer que utilizador criou que categoria*/
    public class Categorias_Utilizador
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("UtilizadorID")]
        public virtual Utilizador Utilizador { get; set; }
    }
}
