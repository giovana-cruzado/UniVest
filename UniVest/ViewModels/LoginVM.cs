using System.ComponentModel.DataAnnotations;
namespace UniVest.ViewModels;

public class LoginVM
{
    [Display(Name = "Email ou Nome de Usuário", Prompt = "Digite seu email ou nome de usuário")]
    [Required(ErrorMessage = "Informe o email ou nome de usuário.")]

    public string Email { get; set; }

    [Display(Name = "Senha", Prompt = "Digite sua senha")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9]).+$",
        ErrorMessage = "A senha deve conter ao menos 1 caractere especial, 1 letra minúscula, 1 letra maiúscula e no mínimo 6 caracteres.")]
    [DataType(DataType.Password)]

    public string Senha { get; set; }

    [Display(Name = "Manter conectado?")]

    public bool Lembrar { get; set; } = false;

    public string UrlRetorno { get; set; }
}
