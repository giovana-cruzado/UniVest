using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Universidade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public List<Campus> Campi { get; set; }
    }
}
