using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniVest.Data;
using UniVest.Models;

namespace UniVest.Controllers
{
    public class VestibularesController : Controller
    {
        private readonly AppDbContext _context;

        public VestibularesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vestibulares
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Vestibular.Include(v => v.Universidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Vestibulares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestibular = await _context.Vestibular
                .Include(v => v.Universidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vestibular == null)
            {
                return NotFound();
            }

            return View(vestibular);
        }

        // GET: Vestibulares/Create
        public IActionResult Create()
        {
            ViewData["UniversidadeId"] = new SelectList(_context.Universidades, "Id", "Nome");
            return View();
        }

        // POST: Vestibulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPrevista1,DataPrevista2,DataPrevista3,DataPrevista4,Nome,PrecoInscricao,Edital,UniversidadeId")] Vestibular vestibular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vestibular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversidadeId"] = new SelectList(_context.Universidades, "Id", "Nome", vestibular.UniversidadeId);
            return View(vestibular);
        }

        // GET: Vestibulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestibular = await _context.Vestibular.FindAsync(id);
            if (vestibular == null)
            {
                return NotFound();
            }
            ViewData["UniversidadeId"] = new SelectList(_context.Universidades, "Id", "Nome", vestibular.UniversidadeId);
            return View(vestibular);
        }

        // POST: Vestibulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPrevista1,DataPrevista2,DataPrevista3,DataPrevista4,Nome,PrecoInscricao,Edital,UniversidadeId")] Vestibular vestibular)
        {
            if (id != vestibular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vestibular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VestibularExists(vestibular.Id))
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
            ViewData["UniversidadeId"] = new SelectList(_context.Universidades, "Id", "Nome", vestibular.UniversidadeId);
            return View(vestibular);
        }

        // GET: Vestibulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestibular = await _context.Vestibular
                .Include(v => v.Universidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vestibular == null)
            {
                return NotFound();
            }

            return View(vestibular);
        }

        // POST: Vestibulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vestibular = await _context.Vestibular.FindAsync(id);
            if (vestibular != null)
            {
                _context.Vestibular.Remove(vestibular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VestibularExists(int id)
        {
            return _context.Vestibular.Any(e => e.Id == id);
        }
    }
}
