using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome da Sala")]
        [StringLength(10, ErrorMessage = "Limite máximo é 10 carateres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Capacidade da Sala")]
        [Range(50,150, ErrorMessage =" A capacidade da sala deve ser entre 50 e 150 lugares")]
        public int Capacidade { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Lugares Disponíveis")]
        [Range(50, 150, ErrorMessage = "Deve haver entre 50 e 150 lugares disponíveis na sala")]
        public int lugaresDisponiveis { get; set; }
    }
}
