using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Vestibular
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPrevista1 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPrevista2 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPrevista3 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPrevista4 { get; set; }

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
