using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projetos.CrudMvc.Models;


namespace Projetos.CrudMvc.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        
        public DbSet<ContatoModel> Contatos { get; set;}
        public DbSet<UsuarioModel> Usuarios  { get; set;}
    }
}