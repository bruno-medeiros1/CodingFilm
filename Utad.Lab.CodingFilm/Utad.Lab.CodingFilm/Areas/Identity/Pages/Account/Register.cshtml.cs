using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Utad.Lab.CodingFilm.Data;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.WebApp.Models;

namespace Utad.Lab.CodingFilm.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly UserManager<Utilizador> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        //dependency injection
        private readonly RoleManager<IdentityRole> _roleManager;

        // dependency injection
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required(ErrorMessage = "Campo obrigatório")]
            [Display(Name = "Nome de Utilizador")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Campo obrigatório")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Campo obrigatório")]
            [StringLength(100, ErrorMessage = "A {0} deve ter um cumprimento entre {2} e {1} carateres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }


            [Required(ErrorMessage = "Campo obrigatório")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "As passwords não coincidem.")]
            public string ConfirmPassword { get; set; }


            [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "O número NIF introduzido não é valido")]
            [Display(Name = "NIF")]
            public decimal? Nif { get; set; }

            [Required(ErrorMessage = "Campo obrigatório"), StringLength(40, ErrorMessage = "Limite Máximo é 40 carateres")]
            public string Nome { get; set; }

            [StringLength(100, ErrorMessage = "Limite máximo é 100 carateres")]
            public string Morada { get; set; }

            [Required(ErrorMessage = "Campo obrigatório")]
            [DataType(DataType.PhoneNumber, ErrorMessage = ("O número de telefone introduzido não é valido"))]
            public string Telefone { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //adicionamos um novo IdentityUser
                var user = new Utilizador { UserName = Input.Username, Email = Input.Email, PhoneNumber = Input.Telefone };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Adicionamos um registo na tabela perfil
                    Perfil perfil = new Perfil
                    {
                        Nome = Input.Nome,
                        Nif = Input.Nif,
                        Morada = Input.Morada,
                        utilizador = user
                    };

                    _context.Perfil.Add(perfil);
                    await _context.SaveChangesAsync();

                    // Adicionamos o role de cliente a quem se registar
                    await _userManager.AddToRoleAsync(user, "Cliente");


                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
