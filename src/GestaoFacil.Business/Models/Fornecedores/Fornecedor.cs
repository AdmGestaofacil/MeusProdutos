using GestaoFacil.Business.Core.Models;
using GestaoFacil.Business.Models.Fornecedores.Validation;
using GestaoFacil.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Fornecedores
{
    public class Fornecedor :Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /*EF RELATIONS*/
        public ICollection<Produto> Produtos { get; set; }

        /*
            podemos usar o validação abaixa para validar  a propria instancia da entidade
             de fornecedor mas vamos fazer de outra forma
        */

        //public bool Validacao()
        //{
        //    var validacao = new FornecedorValidation();
        //    var resultado = validacao.Validate(this);
        //    return resultado.IsValid;
        //}

    }



}
