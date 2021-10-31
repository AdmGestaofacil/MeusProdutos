using GestaoFacil.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Fornecedores
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        /*
         Estou criando metodos especilizados para essa entidade pois os outros metodos 
        já estao sendo herdados da interface IRepository GENERICA.
         */
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id);

    }
}
