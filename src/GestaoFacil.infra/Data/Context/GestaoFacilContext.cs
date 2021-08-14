using GestaoFacil.Business.Models.Fornecedores;
using GestaoFacil.Business.Models.Produtos;
using GestaoFacil.infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Context
{
    public class GestaoFacilContext : DbContext
    {
        public GestaoFacilContext():base("DefaultConnection")
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
        }
    }
}
