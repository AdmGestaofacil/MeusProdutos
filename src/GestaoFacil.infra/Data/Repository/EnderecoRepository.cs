using GestaoFacil.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;

namespace GestaoFacil.infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorid)
        {
            return await ObterPorId(fornecedorid);
        }
    }
}
