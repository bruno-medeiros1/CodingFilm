using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Sessão
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FilmeID")]
        public virtual Filme Filme { get; set; }

        [ForeignKey("SalaID")]
        public virtual Sala Sala { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome da Sessão")]
        [StringLength(20, ErrorMessage = "Limite máximo é 20 carateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data da Sessão")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Horário da Sessão")]
        [Range(typeof(TimeSpan), "14:00", "23:00", ErrorMessage = "Insira um valor entre as 14h e as 23h")]
        public TimeSpan Horário { get; set; }

    }
}
