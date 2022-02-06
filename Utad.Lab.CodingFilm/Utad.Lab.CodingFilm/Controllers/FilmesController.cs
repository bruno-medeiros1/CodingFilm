using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Utad.Lab.CodingFilm.Areas.Admin.Models;
using Utad.Lab.CodingFilm.Models;
using Utad.Lab.CodingFilm.Areas.Admin.ViewModels;
using Utad.Lab.CodingFilm.Data;

namespace Utad.Lab.CodingFilm.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public FilmesController(ApplicationDbContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Pages(int Id)
        {
            //Verificar se o nome introduzido já existe na base de dados
            var filmedb = await _context.Filme.Include(f => f.Categoria).FirstOrDefaultAsync(filme => filme.Id == Id);

            if (filmedb == null)
            {
                return NotFound();
            }
            else
            {
                //Popular uma lista com o valor de todas as sessões do filme

                List<SessãoViewModel> sessões = new List<SessãoViewModel>();

                IList<Sessão> sessaodblist = _context.Sessão.Include(s => s.Filme).Include(s => s.Sala).ToList();

                foreach (var sessão in sessaodblist)
                {
                    //para cada sessão em que o filme seja o pretendido crio um objeto
                    if (sessão.Filme != null)
                    {
                        if (sessão.Filme.Nome.Equals(filmedb.Nome)) 
                        {
                            // crio um objeto
                            SessãoViewModel _sessão = new SessãoViewModel
                            {
                                nome = sessão.Nome,
                                data = sessão.Data,
                                horário = sessão.Horário,
                                nomeSala = sessão.Sala.Nome,
                                lugaresDisponiveis = sessão.Sala.lugaresDisponiveis,
                            };

                            sessões.Add(_sessão);
                        }
                    }
                }
                ViewData["Sessões"] = sessões;

                //Enviar o filme para a view
                return View(filmedb);
            }
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            //Verificar se o nome introduzido já existe na base de dados
            var filmedb = await _context.Filme.Include(f => f.Categoria).FirstOrDefaultAsync(item => item.Id == Id);

            if (filmedb == null)
            {
                return NotFound();
            }
            else
            {
                // crio um objeto
                FilmeViewModel filmeviewmodel = new FilmeViewModel
                {
                    FilmeId = filmedb.Id,
                    nome = filmedb.Nome,
                    descrição = filmedb.Descrição,
                    duração = filmedb.Duração,
                    foto = filmedb.Foto,
                    realizador = filmedb.Realizador,
                    nomeCategoria = filmedb.Categoria.Nome,  
                    pais = filmedb.pais,
                    trailerLink = filmedb.trailerLink,
                    dataEstreia = filmedb.dataEstreia
            };

                // Lista da tabela Categoria
                IList<Categoria> categorias = _context.Categoria.ToList();
                ViewData["Categorias"] = categorias;

               
                IList<Sessão> dbsessões = _context.Sessão.Include(s => s.Sala).ToList();

                //  Enviar lista de sessões do filme em especifico para
                //  mostrar no horário
                List<Sessão> sessões = new List<Sessão>();
                foreach(var sessao in dbsessões) 
                {
                    if(sessao.Filme != null) 
                    {
                        if (sessao.Filme.Nome.Equals(filmedb.Nome))
                        {
                            sessões.Add(sessao);
                        }
                    }
                }

                ViewData["Sessões"] = sessões;

                //  Enviar as sessões que não possuem nenhum filme associado
                //  para podermos adicionar mais sessões a um filme
                List<Sessão> sessõesdisponiveis = new List<Sessão>();

                foreach(var sessãodb in dbsessões) 
                {
                    if(sessãodb.Filme == null) 
                    {
                        sessõesdisponiveis.Add(sessãodb);
                    }
                }

                ViewData["SessõesDisponiveis"] = sessõesdisponiveis;

                return View(filmeviewmodel);
            }
        }




        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        { 
            var filmedb = await _context.Filme.Include(f => f.Categoria).FirstOrDefaultAsync(f => f.Id == Id);
            return View(filmedb);
        }





        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            //Remover todas as tabelas que tiverem associadas ao filme (FKs), neste caso são:
            // -> Filmes_Utilizador
            // -> Sessao

            // Filmes_Utilizador (Tabela que guarda quem criou os filmes)
            // visto que esse mesmo filme será apagado não faz sentido guardarmos 
            // um registo da criação de um filme que já não existe, portanto apagamos
            var filme_utilizadordb = await _context.Filmes_Utilizador.Include(f => f.Filme).FirstOrDefaultAsync(item => item.Filme.Id == Id);
            _context.Remove(filme_utilizadordb);

            // A seguir devemos deixar a NULL o parametro filme, qualquer sessão que esteja ligada a aquele filme
            var lista_sessoes = await _context.Sessão.Include(f => f.Filme).Where(item => item.Filme.Id == Id).ToListAsync();
            foreach(var sessao in lista_sessoes) 
            {
                sessao.Filme = null;
            }

            // Por fim apagamos o filme da tabela Filme
            var filme = await _context.Filme.FindAsync(Id);
            _context.Filme.Remove(filme);


            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



        
        [HttpGet]
        [Authorize(Roles = "Admin, Funcionário, Cliente")]
        public IActionResult Lista() 
        {
            //  Lista das categorias existentes
            IList<Categoria> categorias = _context.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            //  lista das categorias preferidas do utilizador
            var userId = _userManager.GetUserId(User);

            //  com isto obtemos o id da lista de categorias favoritas
            var listaFavoritosdb = _context.CategoriasFavoritas_Utilizador.Include(f => f.Utilizador).Where(c => c.Utilizador.Id == userId).FirstOrDefault();
            IList<CategoriasFavoritas> listacategoriasdb = _context.CategoriasFavoritas.Include(c => c.Categoria).Where(i => i.CategoriaFavoritaID == listaFavoritosdb).ToList();




            ViewData["CategoriasPreferidas"] = listacategoriasdb;

            return View();
        }


        [Authorize(Roles = "Admin, Funcionário, Cliente")]
        [HttpPost]
        public async Task<IActionResult> Lista(IFormCollection formdata) 
        {
            //  encontrar categoria com esse nome
            string nomeCategoria = formdata["inputnome"];
            Categoria categoria = await _context.Categoria.Where(n => n.Nome.Equals(nomeCategoria)).FirstOrDefaultAsync();


            /*  Verificar se a lista de categorias está vazia */
            var userId = _userManager.GetUserId(User);
            var listaFavoritosdb = _context.CategoriasFavoritas_Utilizador.Include(f => f.Utilizador).Where(c => c.Utilizador.Id == userId).FirstOrDefault();

            if (listaFavoritosdb == null)
            {
                //Esta vazia -> 1º registo

                var utilizador = await _userManager.GetUserAsync(User);
                CategoriasFavoritas_Utilizador listacategoria_user = new CategoriasFavoritas_Utilizador
                {
                    Utilizador = utilizador,
                };

                _context.CategoriasFavoritas_Utilizador.Add(listacategoria_user);

                //  Adicionar categorias favoritas noutra tabela

                CategoriasFavoritas categoriafavorita = new CategoriasFavoritas
                {
                    Categoria = categoria,
                    CategoriaFavoritaID = listacategoria_user,
                };

                _context.CategoriasFavoritas.Add(categoriafavorita);
                await _context.SaveChangesAsync();
                TempData["Success"] = "A categoria "+ nomeCategoria + " foi adicionada à tua lista de favoritos";
            }
            else
            {

                //  verificar se a categoria já foi adicionada à lista do utilizador

                var result = await _context.CategoriasFavoritas.Include(c => c.Categoria).Where(u => u.Categoria.Nome == nomeCategoria).Where(u=> u.CategoriaFavoritaID == listaFavoritosdb).FirstOrDefaultAsync();

                if(result == null) 
                {
                    //  Adicionar categorias favoritas noutra tabela
                    CategoriasFavoritas categoriafavorita = new CategoriasFavoritas
                    {
                        Categoria = categoria,
                        CategoriaFavoritaID = listaFavoritosdb,
                    };

                    _context.CategoriasFavoritas.Add(categoriafavorita);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "A categoria " + nomeCategoria + " foi adicionada à tua lista de favoritos";
                }
                else 
                {
                    TempData["NoSuccess"] = "A categoria " + nomeCategoria + " já foi adicionada à tua lista de favoritos";
                }
            }

            Lista();
            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Cartaz()
        {
            IList<Filme> filmeslist = await _context.Filme.ToListAsync();
            if(filmeslist != null) 
            {
                TempData["Success"] = "Lista de filmes disponíveis";
                return PartialView("_FilmesPartial", filmeslist);
            }
            return NotFound();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ProcurarCategoria(string nomeCategoria)
        {
            //Verificar se o nome introduzido já existe na base de dados
            var filmedb = await _context.Filme.Include(f => f.Categoria).Where(f => f.Categoria.Nome.Equals(nomeCategoria)).ToListAsync();

            if(filmedb != null) 
            {
                IList<Filme> filmes = filmedb;

                if (filmes.Count > 0)
                {
                    TempData["Success"] = "Filmes pertencentes à categoria: " + nomeCategoria;
                    return PartialView("_FilmesPartial", filmes);
                }
                else
                {
                    TempData["NoSuccess"] = "Não existem filmes com a categoria: " + nomeCategoria;
                    IList<Filme> filmeslist = await _context.Filme.ToListAsync();
                    return PartialView("_FilmesPartial", filmeslist);
                }
            }
            return NotFound();

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> OrdenarMaisAntigo()
        {
            var filmes = await _context.Filme.OrderBy(f => f.dataEstreia).ToListAsync();
            TempData["Success"] = "Filmes ordenados por mais antigos";
            return PartialView("_FilmesPartial", filmes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> OrdenarMaisRecente()
        {
            var filmes = await _context.Filme.OrderByDescending(f => f.dataEstreia).ToListAsync();
            if(filmes != null) 
            {
                TempData["Success"] = "Filmes ordenados por mais recentes";
                return PartialView("_FilmesPartial", filmes);
            }
            return NotFound();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ProcurarTitulo(IFormCollection formData)
        {
            string nomeFilme = formData["inputNome"];

            //Verificar se o nome introduzido já existe na base de dados
            var filmedb = await _context.Filme.Where(f => f.Nome.Equals(nomeFilme)).ToListAsync();

            if(filmedb != null) 
            {
                //encontrou o filme
                if (filmedb.Count() != 0)
                {
                    TempData["Success"] = "O filme " + nomeFilme + " foi encontrado!";
                    IList<Filme> filmes = filmedb;
                    return PartialView("_FilmesPartial", filmes);
                }
                else
                {
                    TempData["NoSuccess"] = "O filme " + nomeFilme + " não foi encontrado!";
                    IList<Filme> filmeslist = await _context.Filme.ToListAsync();
                    return PartialView("_FilmesPartial", filmeslist);
                }
            }
            return NotFound();
        }




        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(FilmeViewModel filmeviewmodel) 
        {

            if (ModelState.IsValid)
            {

                //  Referência categoria
                Categoria categoria = await _context.Categoria.FirstOrDefaultAsync(item => item.Nome.Equals(filmeviewmodel.nomeCategoria));

                // Referencia Filme
                Filme filme = await _context.Filme.FirstOrDefaultAsync(item => item.Id == filmeviewmodel.FilmeId);

                // Atualização dos parâmetros
                filme.Nome = filmeviewmodel.nome;
                filme.Descrição = filmeviewmodel.descrição;
                filme.Duração = filmeviewmodel.duração;
                filme.Realizador = filmeviewmodel.realizador;
                filme.Categoria = categoria;
                filme.trailerLink = filmeviewmodel.trailerLink;
                filme.pais = filmeviewmodel.pais;
                filme.dataEstreia = filmeviewmodel.dataEstreia;


                _context.Filme.Update(filme);

                //  Atualizar o filme no registo da sessão e colocar como não disponível a sessão
                Sessão sessão = await _context.Sessão.FirstOrDefaultAsync(item => item.Nome.Equals(filmeviewmodel.nomeSessão));
                sessão.Filme = filme;

                //   Atualizamos na Base de Dados
                await _context.SaveChangesAsync();

                //  mensagem de sucesso
                TempData["Success"] = "Filme editado";

                return RedirectToAction("Edit", new { Id = filmeviewmodel.FilmeId });
            }

            return RedirectToAction("Edit",  new { Id = filmeviewmodel.FilmeId });
        }

    }
}
