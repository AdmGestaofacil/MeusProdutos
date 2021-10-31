using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestaoFacil.AppMvc.Models;
using GestaoFacil.AppMvc.ViewModels;
using GestaoFacil.Business.Models.Produtos;
using GestaoFacil.Business.Models.Produtos.Services;
using GestaoFacil.infra.Data.Repository;
using GestaoFacil.Business.Core.Notificacoes;
using AutoMapper;

namespace GestaoFacil.AppMvc.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;//para fazer leitura dos dados
        private readonly IProdutoService _produtoService; // para persistir no banco.
        private readonly IMapper _mapper;
        public ProdutosController()
        {
            
        }

        [Route("lista-de-produtos")]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModels>>(await _produtoRepository.ObterTodos()));
        }

       [Route("dados-do-produto/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
         
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModels produtoViewModels)
        {
            if (ModelState.IsValid)
            {

                await _produtoRepository.Adcionar(_mapper.Map<Produto>(produtoViewModels));
                return RedirectToAction("Index");
            }

            return View(produtoViewModels);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModels produtoViewModels)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModels));
                return RedirectToAction("Index");
            }
            return View(produtoViewModels);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
           
            var produtoViewModels = await ObterProduto(id);
            if (produtoViewModels == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModels);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModels = await ObterProduto(id);
            if (produtoViewModels == null)
            {
                return HttpNotFound();
            }
            await _produtoService.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModels> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModels > (await _produtoRepository.ObterProdutoFornecedor(id));

            return produto;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository.Dispose();
                _produtoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
