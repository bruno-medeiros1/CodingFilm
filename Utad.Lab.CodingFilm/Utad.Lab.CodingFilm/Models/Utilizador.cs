using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.CodingFilm.Models
{
    public class Utilizador : IdentityUser
    {
        /* Propriedades adicionais */
        public byte[] FotoPerfil { get; set; }

        public int UsernameChangeLimit { get; set; } = 1;
    }
}
