using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.ViewModels
{
    /*Esta viewmodel será usado para fazer as validações de 2 modelos num so viewmodel para usar na view*/
    public class UserViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome de Utilizador")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "As passwords devem ser iguais")]
        public string ConfirmPassword { get; set; }


        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "O número NIF introduzido não é valido")]
        [Display(Name = "NIF do Utilizador")]
        public decimal? Nif { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), StringLength(40, ErrorMessage = "Limite Máximo é 40 carateres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "Limite máximo é 100 carateres")]
        [Display(Name = "Morada do Utilizador")]
        public string Morada { get; set; }

        /// <summary>
        /// 
        ///  Expressão regular para nº de telefone em PT
        ///
        ///   ^                         # desde o principio
        ///   (?:                       # agrupa sem captura
        ///     9 [1-36] [0-9]          # primeiros 3 digitos quando comecado por 9
        ///   | 2 [12] [0-9]            # primeiros 3 digitos quando comecado por 21 ou 22
        ///   | 2 [35] [1-689]          # primeiros 3 digitos quando comecado por 23 ou 25
        ///   | 2 4 [1-59]              # primeiros 3 digitos quando comecado por 24
        ///   | 2 6 [1-35689]           # primeiros 3 digitos quando comecado por 26
        ///   | 2 7 [1-9]               # primeiros 3 digitos quando comecado por 27
        ///   | 2 8 [1-69]              # primeiros 3 digitos quando comecado por 28
        ///   | 2 9 [1256]              # primeiros 3 digitos quando comecado por 29
        ///   )                         # fim do grupo
        ///   [0-9]{6}                  # finalizado por quaisquer 6 digitos
        ///   $                         # ate ao fim
        ///
        /// ER: ^(?:9[1-36][0-9]|2[12][0-9]|2[35][1-689]|24[1-59]|26[1-35689]|27[1-9]|28[1-69]|29[1256])[0-9]{6}$
        ///
        /// </summary>

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^(?:9[1-36][0-9]|2[12][0-9]|2[35][1-689]|24[1-59]|26[1-35689]|27[1-9]|28[1-69]|29[1256])[0-9]{6}$",
            ErrorMessage = "O número de telefone introduzido não é valido")]
        [Display(Name = "Telefone do Utilizador")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cargo do Utilizador")]
        public string Cargo { get; set; }
    }
}
