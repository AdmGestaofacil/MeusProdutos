using GestaoFacil.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Mappings
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(f => f.Id);
            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("IX_Documento",
                 new IndexAnnotation(new IndexAttribute { IsUnique = true}));  // criando um indice no banco  que nao repete valor o banco

            //criando relacionamento
            HasRequired(f => f.Endereco)   //No momento do cadastro do fornecedor é obrigatorio um endereço.  Posso colocAR O "HasOptional" como opcional também.
               .WithRequiredPrincipal(e => e.Fornecedor); // significa que o principal nessa relação é o fornecedor.

            ToTable("Fornecedores"); // nome tabela a ser criada no banco.


        }
    }
}
