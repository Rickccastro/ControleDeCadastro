using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeContatos.Controllers;
public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }
    public IActionResult Index()
    {
        List<ContatoModel> listaContatos = _contatoRepositorio.BuscarTodos();
        return View(listaContatos);
    }
    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
        return View(contato);
    }
    public IActionResult Excluir(int id)
    {
        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
        return View(contato);
    }
    public IActionResult ExcluirConfirmado(int id)
    {
        try
        {
            bool apagado= _contatoRepositorio.Excluir(id);
           
            if (apagado)
            {
                TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao excluir o contato!";
            }
            return RedirectToAction("Index");
        }
        catch (Exception ex) 
        {
            TempData["MensagemErro"] = $"Erro ao excluir o contato! {ex.Message}";
            return RedirectToAction("Index");
        }
    }


    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch(Exception ex)
        {
            TempData["MensagemErro"] = $"Não conseguimos cadastrar o contato!,por causa:{ex.Message}";
            return RedirectToAction("Index");

        }
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View("Editar",contato);
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = $"Não conseguimos atualizar o contato!,por causa do erro:{ex.Message}";
            return RedirectToAction("Index");

        }
    }

}
