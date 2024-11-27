using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models;

public class ContatoModel
{ 
    public int Id { get; set; }

    [Required(ErrorMessage ="Digite o nome do Contato")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o Email do Contato")]
    [EmailAddress(ErrorMessage = "Digite um Email Valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Digite o Celular do Contato")]
    [Phone(ErrorMessage = "Digite um Celular Valido")]
    public string Celular { get; set; }
}
