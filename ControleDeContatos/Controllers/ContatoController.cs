using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

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
       List<ContatoModel> listaContatos= _contatoRepositorio.BuscarTodos();
        return View(listaContatos);
    }
    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }
    public IActionResult Excluir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
       _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");   
    }
}
