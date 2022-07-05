using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TccAspNet.Models;
using TccAspNet.Data;

namespace TccAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _context;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, Contexto contexto)
        {
            _userManager = userManager;
            _logger = logger;
            _context = contexto;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM home = new()
            {
                Servicos = await _context.Servico.ToListAsync(),
                MEquipe = await _context.Equipe.ToListAsync(),
                PaginasCarrossel = await _context.Carrossel.ToListAsync(),
                Recomendacoes = await _context.Recomendacao.ToListAsync()
            };
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                home.User = user;
                home.Notificacoes = _context.Contato.Where(c => c.UserId == user.Id && !string.IsNullOrEmpty(c.Resposta)).ToList();
                //&& !c.Lida
            }
            return View(home);
        }

        public async Task<IActionResult> Project()
        {
            HomeVM home = new()
            {
                ItensProjeto = await _context.Projeto.Include(p => p.Categoria).ToListAsync(),
                Filtros = await _context.Categoria.ToListAsync()
            };
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                home.User = user;
                home.Notificacoes = _context.Contato.Where(c => c.UserId == user.Id && !string.IsNullOrEmpty(c.Resposta)).ToList();
            }
            return View(home);
        }


        [Authorize(Roles = "Basico")]
        [HttpGet]

        public async Task<IActionResult> Quote()
        {
            HomeVM home = new();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                home.User = user;
                home.Notificacoes = _context.Contato.Where(c => c.UserId == user.Id && !string.IsNullOrEmpty(c.Resposta)).ToList();
            }
            return View(home);
        }

        [Authorize(Roles = "Basico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Quote(HomeVM form)
        {
            //if user not logged in, then go to another form
            //with more inputs, like name, phone, email, service and description
            if (ModelState.IsValid)
            {
                form.User = await _userManager.GetUserAsync(User);
                form.Formulario.UserId = form.User.Id;
                _context.Contato.Add(form.Formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Thanks");

                // _contexto.Add(form);
                // await _contexto.SaveChangesAsync();
                // return View("Thanks");
            }
            else
            {
                return View(form);
            }
        }

        public async Task<IActionResult> Thanks()
        {
            HomeVM home = new();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                home.User = user;
                home.Notificacoes = _context.Contato.Where(c => c.UserId == user.Id && !string.IsNullOrEmpty(c.Resposta)).ToList();
            }
            return View(home);
        }

        public async Task<IActionResult> ReadNotification(int data)
        {
            var contato = _context.Contato.Find(data);
            contato.Lida = true;
            await _context.SaveChangesAsync();
            return View("Index");
        }

    }
}
