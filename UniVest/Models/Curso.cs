using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
        public int UniversidadeId { get; set; } 
        public Universidade Universidade { get; set; }
    }
}
