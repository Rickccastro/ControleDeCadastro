using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;


namespace ControleDeUsuario.Repository;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly BancoContext _bancoContext;
    public UsuarioRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        usuario.DataCadastro = DateTime.Now;
        _bancoContext.Usuario.Add(usuario);
        _bancoContext.SaveChanges();
        return usuario;
    }
    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        var usuarioDb = this.BuscarPorId(usuario.Id);
        if (usuarioDb == null)
        {
            throw new Exception("Ocorre um erro ao atualizar o Usuário");
        }

        usuarioDb.Nome = usuario.Nome;
        usuarioDb.Email = usuario.Email;
        usuarioDb.Login = usuario.Login;
        usuarioDb.Perfil = usuario.Perfil;
        usuarioDb.DataAtualizacao = DateTime.Now;


        _bancoContext.Update(usuarioDb);
        _bancoContext.SaveChanges();
        return usuarioDb;
    }
    public List<UsuarioModel> BuscarTodos()
    {
        return _bancoContext.Usuario.ToList();
    }

    public UsuarioModel BuscarPorId(int id)
    {
        return _bancoContext.Usuario.FirstOrDefault(item => item.Id == id)!;
    }

    public bool Excluir(int id)
    {
        var usuarioDb = this.BuscarPorId(id);
        if (usuarioDb == null)
        {
            throw new Exception("Ocorre um erro ao deletar o Usuário");
        }
        _bancoContext.Usuario.Remove(usuarioDb);
        _bancoContext.SaveChanges();

        return true;
    }
}
