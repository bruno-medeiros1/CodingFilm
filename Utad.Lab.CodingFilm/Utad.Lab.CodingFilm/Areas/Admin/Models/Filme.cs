using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class Filme
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, ErrorMessage = "Limite máximo é 40 carateres")]
        [Display(Name = "Título")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string Descrição { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40)]
        [Display(Name = "Realizador")]
        public string Realizador { get; set; }


        [Display(Name = "Foto")]
        public byte[] Foto { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [Column(TypeName = "time(1)")]
        [Display(Name = "Duração (h:min)")]
        public TimeSpan? Duração { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Link do trailer")]
        public string trailerLink { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "País")]
        public string pais { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data de Estreia")]
        public DateTime? dataEstreia { get; set; }
    }
}
