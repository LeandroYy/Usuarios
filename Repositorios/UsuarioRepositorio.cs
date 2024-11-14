using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Projetos.CrudMvc.Data;
using Projetos.CrudMvc.Models;

namespace Projetos.CrudMvc.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContex;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContex = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
           usuario.DataCadastro = DateTime.Now;
           
            _bancoContex.Usuarios.Add(usuario);
            _bancoContex.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);


            if (usuarioDB == null)

            {
                throw new System.Exception("Ocorreu um erro para deletar");
            }

            _bancoContex.Usuarios.Remove(usuarioDB);
            _bancoContex.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);


            if (usuarioDB == null)
            {
                throw new System.Exception("Ocorreu um erro na atualização!");
            }

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            

            _bancoContex.Usuarios.Update(usuarioDB);
            _bancoContex.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel BuscarPorLogin(string Login)
        {
            return _bancoContex.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == Login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContex.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContex.Usuarios.FirstOrDefault(x => x.Id == id);
        }

    }
}