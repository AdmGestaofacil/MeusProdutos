using GestaoFacil.Business.Core.Models;
using GestaoFacil.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Produtos
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public Guid FornecedorId { get; set; }

        /*EF RELATIONS* /
        public Fornecedor Fornecedor { get; set; }

    }
}
