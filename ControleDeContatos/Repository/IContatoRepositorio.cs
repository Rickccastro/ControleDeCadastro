using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IContatoRepositorio
{
    ContatoModel Adicionar(ContatoModel model);
    ContatoModel Atualizar(ContatoModel model);
    ContatoModel BuscarPorId(int id);
    List<ContatoModel> BuscarTodos();
}
