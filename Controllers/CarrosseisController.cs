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
    public class CarrosseisController : Controller
    {
        private readonly Contexto _context;

        public CarrosseisController(Contexto context)
        {
            _context = context;
        }

        // GET: Carrosseis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrossel.ToListAsync());
        }

        // GET: Carrosseis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrossel = await _context.Carrossel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrossel == null)
            {
                return NotFound();
            }

            return View(carrossel);
        }

        // GET: Carrosseis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrosseis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imagem,Texto,Descricao")] Carrossel carrossel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrossel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrossel);
        }

        // GET: Carrosseis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrossel = await _context.Carrossel.FindAsync(id);
            if (carrossel == null)
            {
                return NotFound();
            }
            return View(carrossel);
        }

        // POST: Carrosseis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagem,Texto,Descricao")] Carrossel carrossel)
        {
            if (id != carrossel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrossel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrosselExists(carrossel.Id))
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
            return View(carrossel);
        }

        // GET: Carrosseis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrossel = await _context.Carrossel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrossel == null)
            {
                return NotFound();
            }

            return View(carrossel);
        }

        // POST: Carrosseis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrossel = await _context.Carrossel.FindAsync(id);
            _context.Carrossel.Remove(carrossel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrosselExists(int id)
        {
            return _context.Carrossel.Any(e => e.Id == id);
        }
    }
}
