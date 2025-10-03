using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniVest.Models;

[Table("CampusCurso")]
public class CampusCurso
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CampusId { get; set; }
    [ForeignKey("CampusId")]
    public Campus Campus { get; set; }

    [Required]
    public int CursoId { get; set; }
    [ForeignKey("CursoId")]
    public Curso Curso { get; set; }

    [Required]
    public int ModalidadeId { get; set; }
    [ForeignKey("ModalidadeId")]
    public Modalidade Modalidade { get; set; }

    [Required]
    public Periodo Periodo { get; set; }

    [Required]
    public int Duracao { get; set; }

}