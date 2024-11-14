using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projetos.CrudMvc.Models;

namespace Projetos.CrudMvc.Repositorio
{
    public interface IContatoRepositorio
    {   
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato); 
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}