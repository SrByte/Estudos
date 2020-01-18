using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers {
    public class CategoriaController : Controller {
        private ApplicationDbContext _contexto;

        public CategoriaController (ApplicationDbContext contexto) {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index () {
            var categorias = _contexto.Categorias.ToList ();
            return View (categorias);
        }

        [HttpGet]
        public IActionResult Salvar () {
            return View ();
        }

        public IActionResult Editar (int id) {

            var categoria = _contexto.Categorias.First (categoria => categoria.ID == id);
            return View ("Salvar", categoria);
        }
         public async Task<IActionResult> Deletar (int id) {

            var categoria = _contexto.Categorias.First (categoria => categoria.ID == id);
            _contexto.Categorias.Remove(categoria);
            await _contexto.SaveChangesAsync();

                        return RedirectToAction ("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Salvar (Categoria modelo) {
           
           if(modelo.ID==0)
           {
            _contexto.Categorias.Add (modelo);
           }
           else
           {
               var categoria=_contexto.Categorias.First(c=>c.ID==modelo.ID);
               categoria.Nome=modelo.Nome;
               categoria.PermiteEstoque=modelo.PermiteEstoque;
           }

            await _contexto.SaveChangesAsync ();
            return RedirectToAction ("Index");
        }

    }
}