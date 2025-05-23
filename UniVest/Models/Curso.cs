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
        
    }
}
