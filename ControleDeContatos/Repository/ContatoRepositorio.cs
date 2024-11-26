using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repository;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly BancoContext _bancoContext;
    public ContatoRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public ContatoModel Adicionar(ContatoModel contato)
    {
        _bancoContext.Contatos.Add(contato);
        _bancoContext.SaveChanges();
        return contato;
    }
    public ContatoModel Atualizar(ContatoModel contato)
    {
        var contatoDb = this.BuscarPorId(contato.Id);
        if (contatoDb == null)
        {
            throw new Exception("Ocorre um erro ao atualizar o contato");
        }

        contatoDb.Nome = contato.Nome;
        contatoDb.Email = contato.Email;
        contatoDb.Celular = contato.Celular;

        _bancoContext.Update(contatoDb);
        _bancoContext.SaveChanges();
        return contatoDb;
    }
    public List<ContatoModel> BuscarTodos()
    {
        return _bancoContext.Contatos.ToList();
    }

    public ContatoModel BuscarPorId(int id)
    {
        return _bancoContext.Contatos.FirstOrDefault(item => item.Id == id)!;
    }

    public bool Excluir(int id)
    {
        var contatoDb = this.BuscarPorId(id);
        if (contatoDb == null)
        {
            throw new Exception("Ocorre um erro ao deletar o contato");
        }
        _bancoContext.Contatos.Remove(contatoDb);
        _bancoContext.SaveChanges();

        return true;
    }
}
