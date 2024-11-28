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
}
