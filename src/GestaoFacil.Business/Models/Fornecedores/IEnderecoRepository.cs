using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Fornecedores
{
    public interface IEnderecoRepository
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid Fornecedorid);
    }
}
