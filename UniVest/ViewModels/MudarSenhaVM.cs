using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniVest.ViewModels;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "A senha atual é obrigatória.")]
    [DataType(DataType.Password)]
    public string SenhaAtual { get; set; }

    [Required(ErrorMessage = "A nova senha é obrigatória.")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
    public string NovaSenha { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar Senha")]
    [Compare("NovaSenha", ErrorMessage = "A nova senha e a confirmação de senha não coincidem.")]
    public string ConfirmarSenha { get; set; }
}