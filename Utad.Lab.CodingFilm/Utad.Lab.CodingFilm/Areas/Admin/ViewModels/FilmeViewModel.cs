using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.ViewModels
{
    public class FilmeViewModel
    {
        [Required]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, ErrorMessage = "Limite máximo é 40 carateres")]
        [Display(Name = "Título do filme")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255)]
        [Display(Name = "Descrição do filme")]
        public string descrição { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40)]
        [Display(Name = "Realizador do filme")]
        public string realizador { get; set; }

        [Display(Name = "Foto do Filme")]
        public byte[] foto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Duração do filme")]
        public TimeSpan? duração { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Limite máximo é 20 carateres")]
        [Display(Name = "Categoria")]
        public string nomeCategoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sessão")]
        [StringLength(20, ErrorMessage = "Limite máximo é 20 carateres")]
        public string nomeSessão { get; set; }

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
