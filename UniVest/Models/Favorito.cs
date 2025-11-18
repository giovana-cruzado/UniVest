using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniVest.Models
{
    public class Favorito
    {
        [Key]
        public int Id { get; set; } 

        public string UsuarioId { get; set; } 
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } 

        public int CampusCursoId { get; set; }
        [ForeignKey("CampusCursoId")]
        public CampusCurso CampusCurso { get; set; }
    }
}
