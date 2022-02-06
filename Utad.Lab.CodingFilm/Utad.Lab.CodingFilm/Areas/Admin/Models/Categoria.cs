using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name="Nome da Categoria")]
        [StringLength(20, ErrorMessage = "Limite máximo é 20 carateres")]
        public string Nome { get; set; }
    }
}
