﻿using GestaoFacil.Business.Core.Models;
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
        public string nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /*EF RELATIONS*/
        public ICollection<Produto> Produtos { get; set; }
    }

}
