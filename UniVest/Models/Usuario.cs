using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace UniVest.Models;

public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [StringLength(200)]
    public string Foto { get; set; }
}