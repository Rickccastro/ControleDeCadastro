using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IContatoRepositorio
{
    ContatoModel Adicionar(ContatoModel model);
    ContatoModel Atualizar(ContatoModel model);
    bool Excluir(int id);   
    ContatoModel BuscarPorId(int id);
    List<ContatoModel> BuscarTodos();
}
