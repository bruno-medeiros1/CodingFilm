using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.ViewModels
{
    public class SessãoViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome da Sessão")]
        [StringLength(20, ErrorMessage = "Limite máximo é 20 carateres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data da Sessão")]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Horário da Sessão")]
        [Range(typeof(TimeSpan), "14:00", "23:00", ErrorMessage = "Insira um valor entre as 14h e as 23h")]
        public TimeSpan horário { get; set; }

        [Display(Name = "Sessão Disponivel")]
        public bool isAvailable { get; set; } = true;

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome da Sala")]
        [StringLength(10, ErrorMessage = "Limite máximo é 10 carateres")]
        public string nomeSala { get; set; }

        [StringLength(40,ErrorMessage = "Limite máximo é 40 carateres")]
        [Display(Name = "Nome do Filme")]
        public string nomeFilme { get; set; }

        [Display(Name = "Lugares disponíveis na sala")]
        public int lugaresDisponiveis { get; set; }
    }
}
