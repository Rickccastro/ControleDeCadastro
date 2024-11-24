using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly BancoContext _bancoContext;
    public ContatoRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public ContatoModel Adicionar(ContatoModel model)
    {
        _bancoContext.Contatos.Add(model);
        _bancoContext.SaveChanges();
        return model;
    }
    public List<ContatoModel> BuscarTodos()
    {
        return _bancoContext.Contatos.ToList();
    }
}
