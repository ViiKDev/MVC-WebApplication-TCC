using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TccAspNet.Data;
using TccAspNet.Models;

namespace TccAspNet.Controllers
{
    [Authorize(Roles = "Admin, Moderador")]
    public class RecomendacoesController : Controller
    {
        private readonly Contexto _context;

        public RecomendacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Recomendacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recomendacao.ToListAsync());
        }

        // GET: Recomendacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacao = await _context.Recomendacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recomendacao == null)
            {
                return NotFound();
            }

            return View(recomendacao);
        }

        // GET: Recomendacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recomendacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Imagem,Profissao,Texto")] Recomendacao recomendacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recomendacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacao);
        }

        // GET: Recomendacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacao = await _context.Recomendacao.FindAsync(id);
            if (recomendacao == null)
            {
                return NotFound();
            }
            return View(recomendacao);
        }

        // POST: Recomendacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Imagem,Profissao,Texto")] Recomendacao recomendacao)
        {
            if (id != recomendacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recomendacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecomendacaoExists(recomendacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacao);
        }

        // GET: Recomendacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacao = await _context.Recomendacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recomendacao == null)
            {
                return NotFound();
            }

            return View(recomendacao);
        }

        // POST: Recomendacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recomendacao = await _context.Recomendacao.FindAsync(id);
            _context.Recomendacao.Remove(recomendacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecomendacaoExists(int id)
        {
            return _context.Recomendacao.Any(e => e.Id == id);
        }
    }
}
