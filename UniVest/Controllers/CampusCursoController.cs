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
    public class CampusCursoController : Controller
    {
        private readonly AppDbContext _context;

        public CampusCursoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CampusCurso
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CampusCurso.Include(c => c.Campus).Include(c => c.Curso).Include(c => c.Modalidade);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CampusCurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campusCurso = await _context.CampusCurso
                .Include(c => c.Campus)
                .Include(c => c.Curso)
                .Include(c => c.Modalidade)
                .FirstOrDefaultAsync(m => m.CampusId == id);
            if (campusCurso == null)
            {
                return NotFound();
            }

            return View(campusCurso);
        }

        // GET: CampusCurso/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Nome");
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome");
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidade, "Id", "Nome");
            ViewData["PeriodoId"] = Enum.GetNames(typeof(Periodo)).ToList();
            return View();
        }

        // POST: CampusCurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CampusId,CursoId,ModalidadeId,Periodo,Duracao")] CampusCurso campusCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campusCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Nome", campusCurso.CampusId);
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome", campusCurso.CursoId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidade, "Id", "Nome", campusCurso.ModalidadeId);
            ViewData["PeriodoId"] = Enum.GetNames(typeof(Periodo)).ToList();
            return View(campusCurso);
        }

        // GET: CampusCurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campusCurso = await _context.CampusCurso.FindAsync(id);
            if (campusCurso == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Nome", campusCurso.CampusId);
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome", campusCurso.CursoId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidade, "Id", "Nome", campusCurso.ModalidadeId);
            ViewData["PeriodoId"] = Enum.GetNames(typeof(Periodo)).ToList();
            return View(campusCurso);
        }

        // POST: CampusCurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CampusId,CursoId,ModalidadeId,Periodo,Duracao")] CampusCurso campusCurso)
        {
            if (id != campusCurso.CampusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campusCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusCursoExists(campusCurso.CampusId))
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
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Nome", campusCurso.CampusId);
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome", campusCurso.CursoId);
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidade, "Id", "Nome", campusCurso.ModalidadeId);
            ViewData["PeriodoId"] = Enum.GetNames(typeof(Periodo)).ToList();
            return View(campusCurso);
        }

        // GET: CampusCurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campusCurso = await _context.CampusCurso
                .Include(c => c.Campus)
                .Include(c => c.Curso)
                .Include(c => c.Modalidade)
                .FirstOrDefaultAsync(m => m.CampusId == id);
            if (campusCurso == null)
            {
                return NotFound();
            }

            return View(campusCurso);
        }

        // POST: CampusCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campusCurso = await _context.CampusCurso.FindAsync(id);
            if (campusCurso != null)
            {
                _context.CampusCurso.Remove(campusCurso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusCursoExists(int id)
        {
            return _context.CampusCurso.Any(e => e.CampusId == id);
        }
    }
}
