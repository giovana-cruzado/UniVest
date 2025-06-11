using System.ComponentModel.DataAnnotations;
namespace UniVest.ViewModels;

public class LoginVM
{
    [Display(Name = "Email ou Nome de Usuário", Prompt = "Digite seu email ou nome de usuário")]
    [Required(ErrorMessage = "É obrigatório informar o email ou nome de usuário.")]

    public string Email { get; set; }

    [Display(Name = "Senha", Prompt = "Digite sua senha")]
    [Required(ErrorMessage = "É obrigatório informar a senha.")]
    [DataType(DataType.Password)]

    public string Senha { get; set; }

    [Display(Name = "Manter conectado?")]

    public bool Lembrar { get; set; } = false;

    public string UrlRetorno { get; set; }
}
