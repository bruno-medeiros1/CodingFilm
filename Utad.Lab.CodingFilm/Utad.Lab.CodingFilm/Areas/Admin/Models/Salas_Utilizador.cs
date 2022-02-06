using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Salas_Utilizador
    {
        /* Classe responsável por nos dizer que utilizador criou que sala*/
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("SalaID")]
        public virtual Sala Sala { get; set; }

        [ForeignKey("UtilizadorID")]
        public virtual Utilizador Utilizador { get; set; }
    }
}
