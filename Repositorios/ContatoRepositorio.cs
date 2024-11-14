using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Projetos.CrudMvc.Data;
using Projetos.CrudMvc.Models;

namespace Projetos.CrudMvc.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContex;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContex = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContex.Contatos.Add(contato);
            _bancoContex.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);


            if (contatoDB == null)

            {
                throw new System.Exception("Ocorreu um erro para deletar");
            }

            _bancoContex.Contatos.Remove(contatoDB);
            _bancoContex.SaveChanges();
            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);


            if (contatoDB == null)
            {
                throw new System.Exception("Ocorreu um erro na atualização!");
            }

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContex.Contatos.Update(contatoDB);
            _bancoContex.SaveChanges();

            return contatoDB;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContex.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContex.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}