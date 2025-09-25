using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UniVest.Models
{
    public class Modalidade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
