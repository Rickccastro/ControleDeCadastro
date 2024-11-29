using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers;
public class UsuarioController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
    public IActionResult Index()
    {
        List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
        return View(usuarios);
    }
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = $"Não conseguimos cadastrar o Usuário!,por causa:{ex.Message}";
            return RedirectToAction("Index");
        }
    }
}
