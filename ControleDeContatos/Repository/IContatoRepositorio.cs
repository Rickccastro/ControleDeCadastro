using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IContatoRepositorio
{
    ContatoModel Adicionar(ContatoModel model);
    List<ContatoModel> BuscarTodos();
}
