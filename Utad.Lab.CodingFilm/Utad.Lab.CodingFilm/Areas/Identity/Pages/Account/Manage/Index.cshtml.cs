using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Utad.Lab.CodingFilm.Data;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.WebApp.Models;

namespace Utad.Lab.CodingFilm.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;

        // dependency injection
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public bool canChangeUsername { get; set; }

        [TempData]
        public string UserNameChangeStatus { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nome de Utilizador")]
            public string Username { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Telefone")]
            [RegularExpression(@"^(?:9[1-36][0-9]|2[12][0-9]|2[35][1-689]|24[1-59]|26[1-35689]|27[1-9]|28[1-69]|29[1256])[0-9]{6}$", ErrorMessage = "O número de telefone introduzido não é valido")]
            public string PhoneNumber { get; set; }

            [Column("NIF", TypeName = "numeric(9, 0)")]
            [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "O número NIF introduzido não é valido")]
            [Display(Name = "NIF")]
            public decimal? Nif { get; set; }

            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [StringLength(100, ErrorMessage = "Limite máximo é 100 carateres")]
            public string Morada { get; set; }

            [Display(Name = "Foto de Perfil")]
            public byte[] FotoPerfil { get; set; }
        }

        private async Task LoadAsync(Utilizador user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var fotoperfil = user.FotoPerfil;

            Username = userName;

            //  Fazer uma query para saber quais são os restantes dados
            Perfil perfil = await _context.Perfil.FirstOrDefaultAsync(item => item.utilizador.Id == user.Id);

            var nome = perfil.Nome;

            Input = new InputModel
            {
                Username = userName,
                PhoneNumber = phoneNumber,
                Email = email,
                Morada = perfil.Morada,
                Nif = perfil.Nif,
                FotoPerfil = fotoperfil,
                Nome = nome,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if(user.UsernameChangeLimit == 0) 
            {
                TempData["canChangeUsername"] = false;
                UserNameChangeStatus = $"Não podes mudar o teu nome de utilizador porque já mudas-te 1 vez.";
            }
            else 
            {
                //Mensagem a avisar quantas vezes o utilizador pode mudar o username
                UserNameChangeStatus = $"Podes mudar o teu nome de utilizador {user.UsernameChangeLimit} vez.";
            }


            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro inesperado a tentar definir o nº de telefone.";
                    return RedirectToPage();
                }
            }

            // Referência Perfil
            Perfil perfil = _context.Perfil.FirstOrDefault(item => item.utilizador.Id == user.Id);


            //  Atualização do Nome
            if (Input.Nome != perfil.Nome   )
            {
                perfil.Nome = Input.Nome;
            }

            // Atualização do NIF
            if (Input.Nif != perfil.Nif)
            {
                perfil.Nif = Input.Nif;
            }

            //  Atualização da Morada
            if (Input.Morada != perfil.Morada)
            {
                perfil.Morada = Input.Morada;
            }

            await _context.SaveChangesAsync();

            //  Atualização da foto de perfil na base de dados
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.FotoPerfil = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            if (user.UsernameChangeLimit > 0)
            {
                if (Input.Username != user.UserName)
                {
                    var userNameExists = await _userManager.FindByNameAsync(Input.Username);
                    if (userNameExists != null)
                    {
                        StatusMessage = "Username de utilizador já existe. Escolhe outro nome.";
                        return RedirectToPage();
                    }
                    var setUserName = await _userManager.SetUserNameAsync(user, Input.Username);
                    if (!setUserName.Succeeded)
                    {
                        StatusMessage = "Erro inesperado ao tentar definir esse nome.";
                        return RedirectToPage();
                    }
                    else
                    {
                        user.UsernameChangeLimit -= 1;
                        StatusMessage = "Username alterado com sucesso!";
                        await _userManager.UpdateAsync(user);
                    }
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "O teu perfil foi atualizado com sucesso.";
            return RedirectToPage();
        }
    }
}
