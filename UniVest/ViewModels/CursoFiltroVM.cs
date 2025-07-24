using UniVest.Models;

public class CursoFiltroVM
{
    public int? CursoId { get; set; }
    public int? UniversidadeId { get; set; }
    public int? CampusId { get; set; }
    public string Estado { get; set; }
    public string Modalidade { get; set; }
    public List<string> Periodos { get; set; }
    public string Periodo { get; set; } // nome do enum selecionado
    public List<Curso> Cursos { get; set; }
    public List<Universidade> Universidades { get; set; }
    public List<Campus> Campi { get; set; }
    public List<string> Estados { get; set; }
    public List<string> Modalidades { get; set; }

    public List<CampusCurso> Resultados { get; set; } // Cursos filtrados
}
