using ComprasPublicas.Infra.Data.Config.Produto;
using ComprasPublicas.Infra.Data.ConnectionsDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasPublicas.Infra.Data.Contexts.Produto
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext() { }

        public ProdutoContext(DbContextOptions option)
          : base(option) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
        }

        public DbSet<Dominio.Entidades.Produto> Produto { get; set; }
    }
}
