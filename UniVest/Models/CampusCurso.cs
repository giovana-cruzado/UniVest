using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniVest.Models;

[Table("CampusCurso")]
public class CampusCurso
{   
    public int Id { get; set; }
    
    [Key, Column(Order = 1)]
    public int CampusId { get; set; }
    [ForeignKey("CampusId")]

    public Campus Campus { get; set; }

    [Key, Column(Order = 2)]
    public int CursoId { get; set; }

    [ForeignKey("CursoId")]
    public Curso Curso { get; set; }

    [Required]
    public Modalidade ModalidadeId { get; set; }

    [Required]
    public Periodo Periodo { get; set; }

}