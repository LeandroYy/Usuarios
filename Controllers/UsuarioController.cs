using Microsoft.AspNetCore.Mvc;
using Projetos.CrudMvc.Models;
using Projetos.CrudMvc.Repositorio;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace crudmvc.Controllers
{
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
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _usuarioRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario =_usuarioRepositorio.ListarPorId(id);            
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario =_usuarioRepositorio.ListarPorId(id);            
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            UsuarioModel usuario = null;
            usuario = new UsuarioModel()
            {
                Id = usuarioSemSenhaModel.Id,
                Nome = usuarioSemSenhaModel.Nome,
                Login = usuarioSemSenhaModel.Login,
                Email = usuarioSemSenhaModel.Email,
                Perfil = usuarioSemSenhaModel.Perfil
            };

            usuario = _usuarioRepositorio.Atualizar(usuario);
            return RedirectToAction("Index");
        }
    }
}