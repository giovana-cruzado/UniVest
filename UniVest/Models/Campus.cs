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
        public string Cidade { get; set; }
        
        [StringLength(50)]
        public string Estado { get; set; }

        public int UniversidadeId { get; set; }

        public Universidade Universidade { get; set; }

    }
}
