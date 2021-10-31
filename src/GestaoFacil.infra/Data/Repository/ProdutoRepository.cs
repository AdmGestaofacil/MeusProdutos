using GestaoFacil.Business.Models.Produtos;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace GestaoFacil.infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
               .Include(a =>a.Fornecedor)
               .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                .Include(x => x.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        
    }
}
