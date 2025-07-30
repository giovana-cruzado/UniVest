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
        public IActionResult Index(CursoFiltroVM filtro)
        {
            var viewModel = new CursoFiltroVM
            {
                Cursos = _context.Curso.ToList(),
                Universidades = _context.Universidades.ToList(),
                Campi = _context.Campus.ToList(),
                Estados = _context.Campus.Select(c => c.Estado).Distinct().ToList(),
                Modalidades = _context.Modalidade.Select(m => m.Nome).Distinct().ToList(),
                Periodos = Enum.GetNames(typeof(Periodo)).ToList()
            };

            var query = _context.CampusCurso
                .Include(cc => cc.Curso)
                .Include(cc => cc.Campus)
                    .ThenInclude(c => c.Universidade)
                .Include(cc => cc.Modalidade)
                .AsQueryable();

            if (filtro.CursoId.HasValue)
                query = query.Where(cc => cc.CursoId == filtro.CursoId.Value);

            if (filtro.UniversidadeId.HasValue)
                query = query.Where(cc => cc.Campus.UniversidadeId == filtro.UniversidadeId.Value);

            if (filtro.CampusId.HasValue)
                query = query.Where(cc => cc.CampusId == filtro.CampusId.Value);

            if (!string.IsNullOrEmpty(filtro.Estado))
                query = query.Where(cc => cc.Campus.Estado == filtro.Estado);

            if (!string.IsNullOrEmpty(filtro.Modalidade))
                query = query.Where(cc => cc.Modalidade.Nome == filtro.Modalidade);

            if (!string.IsNullOrEmpty(filtro.Periodo) && Enum.TryParse<Periodo>(filtro.Periodo, out var periodoEnum))
                query = query.Where(cc => cc.Periodo == periodoEnum);

            viewModel.Resultados = query.ToList();

            return RedirectToAction("BuscaCursos");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidade == null) return NotFound();

            return View(universidade);
        }

        public IActionResult BuscaCursos()
        {
            CursoFiltroVM c = new();
            return View(c);
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
            if (id == null) return NotFound();

            var universidade = await _context.Universidades.FindAsync(id);
            if (universidade == null) return NotFound();

            return View(universidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sigla,Cidade,Estado")] Universidade universidade)
        {
            if (id != universidade.Id) return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(universidade);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var universidade = await _context.Universidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidade == null) return NotFound();

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
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadeExists(int id)
        {
            return _context.Universidades.Any(e => e.Id == id);
        }
    }
}
