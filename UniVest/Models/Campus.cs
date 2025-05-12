using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Campus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        public int UniversidadeId { get; set; }
        public Universidade Universidade { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}
