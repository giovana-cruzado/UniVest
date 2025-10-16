using System.ComponentModel.DataAnnotations;

namespace UniVest.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
