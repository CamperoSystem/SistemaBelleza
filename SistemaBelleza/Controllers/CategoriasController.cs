using SistemaBelleza.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class CategoriasController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = db.categorias.ToList();
            return View("~/Views/Categorias/CategoriasL.cshtml", categorias);
        }

        // GET: Categorias/Crear
        public ActionResult Crear()
        {
            return View("~/Views/Categorias/CategoriasC.cshtml");
        }

        // POST: Categorias/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Categorias/CategoriasC.cshtml", categoria);
        }

        // GET: Categorias/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = db.categorias.Find(id);
            if (categoria == null)
                return HttpNotFound();

            return View("~/Views/Categorias/CategoriasE.cshtml", categoria);
        }

        // POST: Categorias/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(categoria model)
        {
            if (ModelState.IsValid)
            {
                var categoriaExistente = db.categorias.Find(model.id_categoria);
                if (categoriaExistente != null)
                {
                    categoriaExistente.nombre_categoria = model.nombre_categoria;
                    categoriaExistente.descripcion = model.descripcion;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("~/Views/Categorias/CategoriasE.cshtml", model);
        }

        // GET: Categorias/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = db.categorias.Find(id);
            if (categoria == null)
                return HttpNotFound();

            return View("~/Views/Categorias/CategoriasB.cshtml", categoria);
        }

        // POST: Categorias/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var categoria = db.categorias.Find(id);
            if (categoria != null)
            {
                db.categorias.Remove(categoria);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
