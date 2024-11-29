using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;
namespace ControleDeContatos.Models;

public class UsuarioModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o Nome do Usuário")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o Login do Usuário")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Digite o Email do Usuário")]
    [EmailAddress(ErrorMessage = "Digite um Email Valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Digite a Senha do Usuário")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Digite o Perfil do Usuário")]
    public PerfilEnum Perfil { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}

