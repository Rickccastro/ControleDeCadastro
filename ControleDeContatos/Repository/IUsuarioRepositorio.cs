using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public interface IUsuarioRepositorio
{
    UsuarioModel Adicionar(UsuarioModel model);
    UsuarioModel Atualizar(UsuarioModel model);
    bool Excluir(int id);
    UsuarioModel BuscarPorId(int id);
    List<UsuarioModel> BuscarTodos();
}
