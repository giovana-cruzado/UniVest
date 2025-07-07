using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniVest.Data;
using UniVest.Models;
using Microsoft.AspNetCore.Authorization;

namespace UniVest.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly AppDbContext _context;

        public UniversidadesController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universidades.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidade == null)
            {
                return NotFound();
            }

            return View(universidade);
        }   

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sigla,Cidade,Estado")] Universidade universidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universidade);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades.FindAsync(id);
            if (universidade == null)
            {
                return NotFound();
            }
            return View(universidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sigla,Cidade,Estado")] Universidade universidade)
        {
            if (id != universidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadeExists(universidade.Id))
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
            return View(universidade);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidade == null)
            {
                return NotFound();
            }

            return View(universidade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universidade = await _context.Universidades.FindAsync(id);
            if (universidade != null)
            {
                _context.Universidades.Remove(universidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadeExists(int id)
        {
            return _context.Universidades.Any(e => e.Id == id);
        }
    }
}
