using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniVest.Models;
using UniVest.Data;
using Microsoft.EntityFrameworkCore;
using UniVest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using UniVest.Helpers;
using System.Security.Claims;

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

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Detalhes(int id)
    {
        return View(await GetCampusCurso(id));
    }

    [HttpGet]
    public IActionResult Cursos()
    {
        CursoFiltroVM c = new()
        {
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

    [Authorize]
    public async Task<IActionResult> Favorito()
    {
        var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var usuario = _db.Usuario.FirstOrDefault(u => u.Id == usuarioId);
        if (usuario == null)
            return RedirectToAction("Login", "Account");

        var favoritos = _db.Favorito
            .Where(f => f.UsuarioId == usuarioId)
            .ToList();
       
        var cursosFavoritados = new List<CursoFavoritadoViewModel>();
        foreach (var favorito in favoritos) 
        {
            var campusCurso = await _db.CampusCurso
                .Include(cc => cc.Curso)
                .Include(cc => cc.Modalidade)
                .Include(cc => cc.Campus)
                    .ThenInclude(c => c.Universidade)
                .Include(cc => cc.Campus)
                    .ThenInclude(u => u.Cidade)
                .FirstOrDefaultAsync(cc => cc.Id == favorito.CampusCursoId);
            
            cursosFavoritados.Add(
                new() {
                    CampusCursoId = campusCurso.Id,
                    NomeCurso = campusCurso.Curso.Nome,
                    NomeUniversidade = campusCurso.Campus.Universidade.Nome,
                    Cidade = campusCurso.Campus.Cidade,
                    CursoId = campusCurso.CursoId,
                    Estado = campusCurso.Campus.Estado,
                    Modalidade = campusCurso.Modalidade.Nome
                }       
            );
        }
        FavoritoVM favoritosVM = new() {
            CursosFavoritados = cursosFavoritados
        };
        return View(favoritosVM);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



    private async Task<Detalhe> GetCampusCurso(int id) {
        
        var campusCurso = await _db.CampusCurso
            .Include(cc => cc.Curso)
            .Include(cc => cc.Modalidade)
            .Include(cc => cc.Campus)
                .ThenInclude(c => c.Universidade)
            .FirstOrDefaultAsync(cc => cc.Id == id);

        if (campusCurso == null)
        {
            return null;
        }

        var editalUni = _db.Vestibular
            .OrderByDescending(v => v.DataPrevista1)
            .FirstOrDefault(v => v.UniversidadeId == campusCurso.Campus.UniversidadeId).EditalUni;
        var editalProvao = _db.Vestibular
            .OrderByDescending(v => v.DataPrevista1)
            .FirstOrDefault(v => v.UniversidadeId == campusCurso.Campus.UniversidadeId).EditalProvao;
        

        var viewModel = new Detalhe
        {
            CampusCursoId = campusCurso.Id,
            UniversidadeNome = campusCurso.Campus.Universidade.Nome,
            CursoNome = campusCurso.Curso.Nome,
            Estado = campusCurso.Campus.Estado,
            Periodo = campusCurso.Periodo.GetDisplayName(),
            CampusNome = campusCurso.Campus.Nome,
            Modalidade = campusCurso.Modalidade.Nome,
            DuracaoSemestre = campusCurso.Duracao,
            Img = "/images/placeholder-camera.png",
            EditalUni = editalUni,
            EditalProvao = editalProvao
        };

        return viewModel;

    }
}
