using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Sessões_Utilizador
    {
        /* Classe responsável por nos dizer que utilizador criou que sessão*/
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("SessãoID")]
        public virtual Sessão Sessão { get; set; }

        [ForeignKey("UtilizadorID")]
        public virtual Utilizador Utilizador { get; set; }
    }
}
