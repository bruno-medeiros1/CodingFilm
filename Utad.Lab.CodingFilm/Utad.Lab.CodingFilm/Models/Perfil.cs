using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.WebApp.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        [Column("NIF", TypeName = "numeric(9, 0)")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "O número NIF introduzido não é valido")]
        [Display(Name = "NIF")]
        public decimal? Nif { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), StringLength(40, ErrorMessage = "Limite Máximo é 40 carateres")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "Limite máximo é 100 carateres")]
        public string Morada { get; set; }

        // chave estrangeira que referencia o ID da tabela IdentityUseres
        [ForeignKey("UtilizadoresID")]
        public virtual Utilizador utilizador { get; set; }
    }

}
