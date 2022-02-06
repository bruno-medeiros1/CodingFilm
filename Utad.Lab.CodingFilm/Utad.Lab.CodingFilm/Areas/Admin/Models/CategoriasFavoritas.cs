using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Areas.Admin.Models
{
    public class CategoriasFavoritas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoriasFavoritas_UtilizadorID")]
        public virtual CategoriasFavoritas_Utilizador CategoriaFavoritaID { get; set; }

        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }
    }
}
