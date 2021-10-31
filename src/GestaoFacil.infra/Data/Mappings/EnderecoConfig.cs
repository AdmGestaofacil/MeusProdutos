using GestaoFacil.Business.Models.Fornecedores;
using GestaoFacil.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Mappings
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {

            HasKey(p => p.Id);

            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();  //só aceita 8 caractres nem menos nem mais.

            Property(c => c.Complemento)
                .IsRequired()
                .HasMaxLength(250);

            Property(c => c.Bairro)
                .IsRequired();
                //.HasMaxLength(100);

            Property(c => c.Cidade)
                .IsRequired();
            //.HasMaxLength(100);

            Property(c => c.Estado)
                .IsRequired();
                //.HasMaxLength(100);

            ToTable("Enderecos");


        }
    }
}
