using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Utad.Lab.CodingFilm.Areas.Admin.Models;
using Utad.Lab.CodingFilm.Areas.Admin.ViewModels;
using Utad.Lab.CodingFilm.Data;
using Utad.Lab.CodingFilm.Models;

namespace Utad.Lab.CodingFilm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            // Enviar lista de filmes disponíveis
            IList<Filme> filmes = _context.Filme.ToList();

            ViewData["Filmes"] = filmes;

            IList<Categoria> categorias = _context.Categoria.ToList();
            ViewData["Categorias"] = categorias;

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
