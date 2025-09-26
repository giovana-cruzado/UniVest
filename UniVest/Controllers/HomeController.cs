using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniVest.Models;
using UniVest.Data;
using Microsoft.EntityFrameworkCore;
using UniVest.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace UniVest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Cursos()
    {
        CursoFiltroVM c = new() {
            Cursos = _db.Curso.ToList(),
            Universidades = _db.Universidades.ToList(),
            Campi = _db.Campus.ToList(),
            Estados = _db.Campus.Select(c => c.Estado).Distinct().ToList(),
            Modalidades = _db.Modalidade.Select(m => m.Nome).Distinct().ToList(),
            Periodos = Enum.GetNames(typeof(Periodo)).ToList(),
            Resultados = _db.CampusCurso
                .Include(cc => cc.Curso)
                .Include(cc => cc.Campus)
                    .ThenInclude(c => c.Universidade)
                .Include(cc => cc.Modalidade)
                .ToList()
        };
        return View(c);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Cursos(CursoFiltroVM filtro)
    {
        var viewModel = new CursoFiltroVM
        {
            Cursos = _db.Curso.ToList(),
            Universidades = _db.Universidades.ToList(),
            Campi = _db.Campus.ToList(),
            Estados = _db.Campus.Select(c => c.Estado).Distinct().ToList(),
            Modalidades = _db.Modalidade.Select(m => m.Nome).Distinct().ToList(),
            Periodos = Enum.GetNames(typeof(Periodo)).ToList()
        };

        var query = _db.CampusCurso
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

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
