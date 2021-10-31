using GestaoFacil.Business.Core.Notificacoes;
using GestaoFacil.Business.Core.Service;
using GestaoFacil.Business.Models.Fornecedores.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Fornecedores.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private static INotificador notificador;

        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                    IEnderecoRepository enderecoRepository,
                                    INotificador notificador) :base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (await FornecedirExistente(fornecedor)) return;

            await _fornecedorRepository.Adcionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (await FornecedirExistente(fornecedor)) return;

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereo(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutoEndereco(id);

            if (fornecedor.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            if (fornecedor.Endereco != null)
            {
                await _enderecoRepository.Remover(fornecedor.Endereco.Id);
            }

            await _fornecedorRepository.Remover(id);
        }

        private async Task<bool> FornecedirExistente(Fornecedor fornecedor)
        {
            var fornecedorExiste = await _fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id);

            if (!fornecedorExiste.Any()) return false;
            
            Notificar("Já existe um fornecedor com esse documeento!");
            return true;
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
