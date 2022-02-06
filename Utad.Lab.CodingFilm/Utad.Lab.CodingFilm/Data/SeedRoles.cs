using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utad.Lab.WebApp.Data
{

    /*Classe responsável por criar os roles por predefinição*/
    public static class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager) 
        {
            if(roleManager.Roles.Any() == false) 
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Funcionário")).Wait();
                roleManager.CreateAsync(new IdentityRole("Cliente")).Wait();
            }

        }
    }
}
