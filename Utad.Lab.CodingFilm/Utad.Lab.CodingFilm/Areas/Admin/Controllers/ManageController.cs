using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Areas.Admin.Models;
using Utad.Lab.CodingFilm.Areas.Admin.ViewModels;
using Utad.Lab.CodingFilm.Data;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.WebApp.Models;

namespace Utad.Lab.CodingFilm.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ManageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageController(ApplicationDbContext context, 
            UserManager<Utilizador> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        [Authorize(Roles = "Admin, Funcionário")]
        [HttpGet]
        public IActionResult Index()
        {
            // Lista da tabela Categoria
            IList<Categoria> categorias = _context.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            // Enviar lista de sessões disponíveis (nao possuem filme atribuido) para atribuir a 1 filme
            IList<Sessão> sessõesdb = _context.Sessão.Include(s => s.Sala).Include(f => f.Filme).ToList();

            List<Sessão> sessões = new List<Sessão>();
            foreach (var sessao in sessõesdb) 
            {
                if(sessao.Filme == null) 
                {
                    sessões.Add(sessao);
                }
            }

            ViewData["Sessões"] = sessões;

            return View();
        }

        [Authorize(Roles = "Admin, Funcionário")]
        [HttpPost]
        public async Task<IActionResult> Index(FilmeViewModel filmeviewmodel)
        {
            //  Primeiro verificamos se existe uma imagem no input se existir adicionamos
            //  isto pq, o filmeviewmodel nao retorna a foto logo temos de executar este codigo primeiro
            if (Request.Form.Files.Count > 0)
            {
                //  Atualização da foto de capa do filme na BD
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    filmeviewmodel.foto = dataStream.ToArray();
                }

                if (ModelState.IsValid)
                {
                    //Verificar se o nome introduzido já existe na base de dados
                    var nomeValidation = await _context.Filme.FirstOrDefaultAsync(u => u.Nome.Equals(filmeviewmodel.nome));

                    if (nomeValidation == null)
                    {

                        //  Adicionamos a categoria que existe com esse nome na BD a esse filme
                        Categoria categoria = _context.Categoria.FirstOrDefault(item => item.Nome.Equals(filmeviewmodel.nomeCategoria));

                        Filme filme = new Filme
                        {
                            Nome = filmeviewmodel.nome,
                            Descrição = filmeviewmodel.descrição,
                            Duração = filmeviewmodel.duração,
                            Foto = filmeviewmodel.foto,
                            Realizador = filmeviewmodel.realizador,
                            Categoria = categoria,
                            pais = filmeviewmodel.pais,
                            trailerLink = filmeviewmodel.trailerLink,
                            dataEstreia = filmeviewmodel.dataEstreia
                        };

                        //  Adicionamos o novo filme à Base de Dados
                        await _context.Filme.AddAsync(filme);

                        //  Adicionamos um registo na Tabela Filmes Utilizador que nós permite saber mais tarde quem inseriu tal filme
                        var user = await _userManager.GetUserAsync(User);
                        Filmes_Utilizador registo = new Filmes_Utilizador { Filme = filme, Utilizador = user, Data = DateTime.Now };
                        var filme_utilizador = await _context.Filmes_Utilizador.AddAsync(registo);


                        //  Atualizar o filme no registo da sessão e colocar como não disponível a sessão
                        Sessão sessão = _context.Sessão.FirstOrDefault(item => item.Nome.Equals(filmeviewmodel.nomeSessão));
                        sessão.Filme = filme;

                        //   Atualizamos na Base de Dados
                        await _context.SaveChangesAsync();

                        //  mensagem de sucesso
                        TempData["Success"] = "Filme adicionado";
                        return RedirectToAction();
                    }
                    else 
                    {
                        ModelState.AddModelError("nome", "Nome introduzido já existe. Insira um nome diferente.");
                    }
                }
            }
            else 
            {
                ModelState.AddModelError("foto", "Insira uma imagem de capa para o filme."); 
            }

           
            Index();
            return View(filmeviewmodel);
        }





        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Sessão()
        {
            // Enviar lista de Sessões disponíveis
            List<SessãoViewModel> sessões = new List<SessãoViewModel>();

            //lista pretendida
            IList<Sessão> sessaodblist = _context.Sessão.Include(s => s.Filme).Include(s => s.Sala).ToList();

            foreach (var sessão in sessaodblist)
            {
                if(sessão.Filme == null) 
                {
                    // crio um objeto
                    SessãoViewModel _sessão = new SessãoViewModel
                    {
                        nome = sessão.Nome,
                        data = sessão.Data,
                        horário = sessão.Horário,
                        nomeSala = sessão.Sala.Nome,
                    };

                    sessões.Add(_sessão);
                }
            }
            ViewData["Sessões"] = sessões;

            List<Sala> salas = _context.Sala.ToList();
            ViewData["Salas"] = salas;

            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Sessão(SessãoViewModel sessãoviewmodel)
        {
            if (ModelState.IsValid)
            {
                var nomeValidation = await _context.Sessão.FirstOrDefaultAsync(u => u.Nome.Equals(sessãoviewmodel.nome));

                // Verificação se o nome da sessão introduzida existe na base de dados
                if (nomeValidation == null)
                {
                    var salaValidation = await _context.Sessão.FirstOrDefaultAsync(s => s.Sala.Nome.Equals(sessãoviewmodel.nomeSala));
                    Sessão sessãoRegistada = salaValidation;

                    // Verificação se a sala que escolhi já foi atribuido a uma outra sessão já registada
                    if(salaValidation == null) 
                    {
                        // Adicionamos à sessão a sala escolhida anteriormente
                        Sala sala = await _context.Sala.FirstOrDefaultAsync(item => item.Nome.Equals(sessãoviewmodel.nomeSala));


                        Sessão sessão = new Sessão
                        {
                            Nome = sessãoviewmodel.nome,
                            Horário = sessãoviewmodel.horário,
                            Data = sessãoviewmodel.data,
                            Sala = sala,                           
                        };

                        // Em caso de não haver quaisquer erros no model adicionamos a sessão à BD
                        var result = await _context.Sessão.AddAsync(sessão);
                        if (result == null)
                        {
                            TempData["Mensagem"] = "Erro inesperado ao adicionar o registo à Base de Dados!";
                            return RedirectToAction();
                        }
                        else
                        {
                            //  Adicionar o registo na tabela Sessões_Utilizador para registar que utilizador criou qual sessão
                            var criador = await _userManager.GetUserAsync(User);
                            Sessões_Utilizador registo = new Sessões_Utilizador { Utilizador = criador, Sessão = sessão, Data = DateTime.Now };
                            await _context.Sessões_Utilizador.AddAsync(registo);

                            await _context.SaveChangesAsync();
                            TempData["Success"] = "Sessão adicionada";
                            return RedirectToAction();
                        }
                    }
                    else 
                    {
                        //  Se já estiver registada numa sessão verificar se o horário escolhido possui
                        //  um intervalo de pelo menos 4h para haver tempo de acabar o filme de uma sessão
                        //  e reproduzir outro na mesma sala
                        if(sessãoviewmodel.data == sessãoRegistada.Data 
                            && sessãoviewmodel.horário.Hours > sessãoRegistada.Horário.Hours - 4 && sessãoviewmodel.horário.Hours < sessãoRegistada.Horário.Hours + 4) 
                        {
                            ModelState.AddModelError("horário", "Já existe uma sessão registada com a mesma sala por volta dessa hora. " +
                                "Escolha um horário com um intervalo de 4h de diferença se usar a mesma sala. Verifique na lista de Sessões disponíveis abaixo ");
                        }
                        else 
                        {
                            //Horário válido
                            // Adicionamos à sessão a sala escolhida anteriormente
                            Sala sala = await _context.Sala.FirstOrDefaultAsync(item => item.Nome.Equals(sessãoviewmodel.nomeSala));


                            Sessão sessão = new Sessão
                            {
                                Nome = sessãoviewmodel.nome,
                                Horário = sessãoviewmodel.horário,
                                Data = sessãoviewmodel.data,
                                Sala = sala,
                            };

                            // Em caso de não haver quaisquer erros no model adicionamos a sessão à BD
                            var result = await _context.Sessão.AddAsync(sessão);
                            if (result == null)
                            {
                                TempData["Mensagem"] = "Erro inesperado ao adicionar o registo à Base de Dados!";
                                return RedirectToAction();
                            }
                            else
                            {
                                //  Adicionar o registo na tabela Sessões_Utilizador para registar que utilizador criou qual sessão
                                var criador = await _userManager.GetUserAsync(User);
                                Sessões_Utilizador registo = new Sessões_Utilizador { Utilizador = criador, Sessão = sessão, Data = DateTime.Now };
                                await _context.Sessões_Utilizador.AddAsync(registo);

                                await _context.SaveChangesAsync();
                                TempData["Mensagem"] = "Sessão adicionada com sucesso!";
                                return RedirectToAction();
                            }
                        }

                    }
                }
                else 
                {
                    ModelState.AddModelError("Nome", "Nome introduzido já existe. Insira um nome diferente.");
                }
            }
            Sessão();
            return View(sessãoviewmodel);
        }





        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Salas()
        {
            IList<Sala> salas = _context.Sala.ToList();
            ViewData["Salas"] = salas;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Salas(Sala sala)
        {
            if (ModelState.IsValid)
            {
                var validation = _context.Sala.FirstOrDefault(u => u.Nome.Equals(sala.Nome));

                // Verificação se o nome da categoria introduzida existe na base de dados
                if (validation == null)
                {
                    // Em caso de não haver quaisquer erros no model adicionamos a sessão à BD
                    var result = await _context.Sala.AddAsync(sala);

                    if (result == null)
                    {
                        return RedirectToAction();
                    }

                    //  Adicionar o registo na tabela Salas_Utilizador para registar que utilizador criou qual sala
                    var criador = await _userManager.GetUserAsync(User);
                    Salas_Utilizador registo = new Salas_Utilizador { Utilizador = criador, Sala = sala, Data = DateTime.Now };
                    await _context.Salas_Utilizador.AddAsync(registo);

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Sala adicionada";
                    return RedirectToAction();
                }
                else 
                {
                    ModelState.AddModelError("Nome", "Nome introduzido já existe. Insira um nome diferente.");
                }
            }
            Salas();
            return View(sala);
        }





        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Categorias()
        {
            IList<Categoria> categorias = _context.Categoria.ToList();
            ViewData["Categorias"] = categorias;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Categorias(Categoria categoria)
        {
            if (ModelState.IsValid) 
            {

                var validation = _context.Categoria.FirstOrDefault(u => u.Nome.Equals(categoria.Nome));

                // Verificação se o nome da categoria introduzida existe na base de dados
                if (validation == null)
                {
                    // Em caso de não haver quaisquer erros no model adicionamos a sessão à BD
                    var result = await _context.Categoria.AddAsync(categoria);

                    if (result == null)
                    {
                        return RedirectToAction();
                    }
                    else 
                    {
                        // Depois de adicionar uma categoria adiciono o registo de quem adicionou essa categoria
                        var user = await _userManager.GetUserAsync(User);
                        Categorias_Utilizador registo = new Categorias_Utilizador { Categoria = categoria, Utilizador = user, Data = DateTime.Now };
                        var categorias_utilizador = await _context.Categorias_Utilizador.AddAsync(registo);


                        await _context.SaveChangesAsync();
                        TempData["Success"] = "Categoria adicionada";
                        return RedirectToAction();
                    }

                }
                else 
                {
                    ModelState.AddModelError("Nome", "Nome introduzido já existe. Insira um nome diferente.");
                }
            }
            Categorias();
            return View(categoria);
        }





        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Utilizadores()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Utilizadores(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                var email = _context.Users.FirstOrDefault(u => u.Email.ToLower() == userviewmodel.Email.ToLower());

                // Verificação de se o email existe
                if (email == null)
                {

                    var user = new Utilizador { UserName = userviewmodel.Username, Email = userviewmodel.Email };
                    var result = await _userManager.CreateAsync(user, userviewmodel.Password);

                    // Verifica se existe um utilizador com esse username
                    if (result.Succeeded)
                    {

                        //  Adicionamos um registo na tabela perfil
                        Perfil perfil = new Perfil
                        {
                            Nome = userviewmodel.Nome,
                            Nif = userviewmodel.Nif,
                            Morada = userviewmodel.Morada,
                            utilizador = user
                        };
                        await _context.Perfil.AddAsync(perfil);

                        //  Adicionamos o role que foi escolhido no formulario
                        await _userManager.AddToRoleAsync(user, userviewmodel.Cargo);

                        //  Adicionar o registo na tabela Cria_Utilizadores para registar que utilizador criou qual
                        var criador = await _userManager.GetUserAsync(User);
                        Cria_Utilizadores registo = new Cria_Utilizadores { Utilizador1 = criador, Utilizador2 = user, Data = DateTime.Now };
                        await _context.Cria_Utilizadores.AddAsync(registo);

                        TempData["Success"] = "Utilizador adicionado";
                        await _context.SaveChangesAsync();
                    }
                    else 
                    {
                        ModelState.AddModelError("Username", "Username introduzido já existe. Insira um username diferente.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Email introduzido já existe. Insira um email diferente.");
                    return View(userviewmodel);
                }
            }
            return View(userviewmodel);
        }





        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Logs()
        {
            // Usamos include para passar informação das chaves estrangeiras também para a lista uma vez que tem a informação que desejamos
            IList<Categorias_Utilizador> logs_categorias = _context.Categorias_Utilizador.Include( c => c.Categoria).Include(c=> c.Utilizador).ToList();
            ViewData["Logs_Categorias"] = logs_categorias;

            // Lista da tabela Filmes_Utilizador
            IList<Filmes_Utilizador> logs_filmes = _context.Filmes_Utilizador.Include(c => c.Filme).Include(c => c.Utilizador).ToList();
            ViewData["Logs_Filmes"] = logs_filmes;

            // Lista da tabela Cria_Utilizadores
            IList<Cria_Utilizadores> logs_utilizadores = _context.Cria_Utilizadores.Include(c => c.Utilizador1).Include(c => c.Utilizador2).ToList();
            ViewData["Logs_Utilizadores"] = logs_utilizadores;

            // Lista da tabela Cria_Utilizadores
            IList<Salas_Utilizador> logs_salas = _context.Salas_Utilizador.Include(c => c.Utilizador).Include(c => c.Sala).ToList();
            ViewData["Logs_Salas"] = logs_salas;

            // Lista da tabela Cria_Utilizadores
            IList<Sessões_Utilizador> logs_sessões = _context.Sessões_Utilizador.Include(c => c.Utilizador).Include(c => c.Sessão).ToList();
            ViewData["Logs_Sessões"] = logs_sessões;

            return View();
        }
    }
}
