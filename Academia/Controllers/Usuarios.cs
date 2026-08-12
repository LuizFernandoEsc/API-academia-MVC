 using Academia.Models;
using Academia.Repositório;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers
{
    public class Usuarios : Controller
    {
        private readonly InterfaceUsuarioRepositório _UsuarioRepositório;
        public Usuarios(InterfaceUsuarioRepositório UsuarioRepositório)
        {
            _UsuarioRepositório = UsuarioRepositório;
        }
        public IActionResult Index()
        { 
            List<UsuarioModel> usuarios= _UsuarioRepositório.BuscarTodos();


            return View(usuarios);
        }

        public IActionResult criar()
        {
            return View();
        }
        public IActionResult editar(int Id)
        {
            UsuarioModel usuario = _UsuarioRepositório.listarPorId(Id);
            return View(usuario);
        }
        public IActionResult ConfirmarExcluir(int Id)
        {
            UsuarioModel usuario = _UsuarioRepositório.listarPorId(Id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult excluir(int Id)
        {
            _UsuarioRepositório.Excluir(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult criar(UsuarioModel usuario)
        {
            _UsuarioRepositório.Adicionar(usuario);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult alterar(UsuarioModel usuario)
        {
            _UsuarioRepositório.Atualizar(usuario);
            return RedirectToAction("Index");
        }
    }
}
