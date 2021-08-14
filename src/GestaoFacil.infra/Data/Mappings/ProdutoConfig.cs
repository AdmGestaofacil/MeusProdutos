using GestaoFacil.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Mappings
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(c => c.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            //Relacionamento
            HasRequired(p => p.Fornecedor)   // preciso de um fornecedor para ter um produto...
             .WithMany(f => f.Produtos)      // um forncedore pode ter muitos produtos. 1:N.
             .HasForeignKey(p => p.FornecedorId);  
        }
    }
}
