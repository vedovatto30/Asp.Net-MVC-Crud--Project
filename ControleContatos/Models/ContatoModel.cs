using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o e-mail do contato")]

        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira o celular")]
        [Phone(ErrorMessage = "Insira o telefone válido")]
        public string Celular { get; set; }
    }
}
