using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    /* Classe responsável por nos dizer que utilizador criou que utilizador
     Sendo que o Utilizador1ID cria o Utilizador2ID
    
     Utilizador1ID --> Utilizador2ID
    */
    public class Cria_Utilizadores
    {
        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Utilizador1ID")]
        public virtual Utilizador Utilizador1 { get; set; }

        [ForeignKey("Utilizador2ID")]
        public virtual Utilizador Utilizador2 { get; set; }
    }
}
