namespace UniVest.Models
{
    public class Favorito
    {
        public int Id { get; set; } 
        public string UsuarioId { get; set; } 
        public Usuario Usuario { get; set; } 
        public int CampusCursoId { get; set; }
        public CampusCurso CampusCurso { get; set; }
    }
}
