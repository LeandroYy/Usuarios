using System;
using Microsoft.AspNetCore.Mvc;
using Projetos.CrudMvc.Models;
using Projetos.CrudMvc.Repositorio;

namespace crudmvc.Controllers
{
    public class LoginController : Controller 
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
           UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

            if(usuario != null) {
                if(usuario.SenhaValida(loginModel.Senha))
                {
                 return RedirectToAction("Index","Home");
                }
            }
            return RedirectToAction("Index","Login");
        }
        
    }
}
