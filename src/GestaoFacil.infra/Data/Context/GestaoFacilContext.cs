using GestaoFacil.Business.Models.Fornecedores;
using GestaoFacil.Business.Models.Produtos;
using GestaoFacil.infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Context
{
    public class GestaoFacilContext : DbContext
    {
        public GestaoFacilContext():base("DefaultConnection")
        {    
            /*Se os caras abaixo tiver ligado ou seja como true a gente perde performace*/
            Configuration.ProxyCreationEnabled = false; 
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Convetions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();   //Colocando o nome das tabelas no plural, nesse caso estou removendo (desabilitando)
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // Deleta tudo que é um  1:N  Ex: deleta fornecedor eu deleto também os produtos   (desabilitando)
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();  // Deleta tudo que é um  N:N   (desabilitando)

            //definindo um padrão para o tipo string ou seja toda string vai ser criado no banco como varchar de 100 por padrão.
            modelBuilder.Properties<string>()
                .Configure(p => p
                .HasColumnType("varchar")
                .HasMaxLength(100));

            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);

        }
    }
}
