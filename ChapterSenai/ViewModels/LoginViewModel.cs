using System.ComponentModel.DataAnnotations;

namespace ChapterSenai.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail correto")] //nao pode deixar o campo vazio
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha correto")]
        public string senha { get; set; }
 
    }
}
