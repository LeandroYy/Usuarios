using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Projetos.CrudMvc.Data;
using Projetos.CrudMvc.Models;

namespace Projetos.CrudMvc.Repositorio
{
    public interface IUsuarioRepositorio{
        
        UsuarioModel BuscarPorLogin(string Login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario); 
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);

    }
}
