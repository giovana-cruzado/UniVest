using System.ComponentModel.DataAnnotations;

namespace UniVest.Models.ViewModels
{
    public class DeletarContaViewModel
    {
        [Required(ErrorMessage = "A senha é obrigatória para confirmar a exclusão.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha de Confirmação")]
        public string SenhaConfirmacao { get; set; }
    }
}
