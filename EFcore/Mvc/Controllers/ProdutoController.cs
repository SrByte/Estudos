using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers {
    public class ProdutoController : Controller {
        private ApplicationDbContext _contexto;

        public ProdutoController (ApplicationDbContext contexto) {
            _contexto = contexto;
        }

        public IActionResult Index () {
            // var produtos = _contexto.Produtos.Include (c => c.Categoria).ToList (); Sem LazyLoad
            var queryDeProdutos = _contexto.Produtos.Where (c => c.Categoria.PermiteEstoque);
            if (!queryDeProdutos.Any ()) {
                return View (new List<Produto> ());
            }

            return View (queryDeProdutos);
        }

        [HttpGet]
        public IActionResult Salvar () {
            ViewBag.Categorias = _contexto.Categorias.ToList ();
            return View ();
        }

        // public IActionResult Editar (int id) {

        //     var produto = _contexto.Produtos.First (produto => produto.ID == id);
        //     return View ("Salvar", produto);
        // }
        // public async Task<IActionResult> Deletar (int id) {

        //     var produto = _contexto.Produtos.First (produto => produto.ID == id);
        //     _contexto.Produtos.Remove (produto);
        //     await _contexto.SaveChangesAsync ();

        //     return RedirectToAction ("Index");
        // }

        [HttpPost]
        public async Task<IActionResult> Salvar (Produto modelo) {

            if (modelo.ID == 0) {
                _contexto.Produtos.Add (modelo);
            } else {
                var produto = _contexto.Produtos.First (c => c.ID == modelo.ID);
                produto.Nome = modelo.Nome;
            }

            await _contexto.SaveChangesAsync ();
            return RedirectToAction ("Index");
        }

    }
}