using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Vestibular
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataPrevista { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public decimal PrecoInscricao { get; set; }

        [StringLength(200)]
        public string Edital { get; set; }

        public int UniversidadeId { get; set; }
        public Universidade Universidade { get; set; }
    }
}
