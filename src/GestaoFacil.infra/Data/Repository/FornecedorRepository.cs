using GestaoFacil.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GestaoFacil.infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public override async Task Remover(Guid id)
        {
            var fornecedor = await ObterPorId(id);
            fornecedor.Ativo = false;
            await Atualizar(fornecedor);
        }
    }
}
