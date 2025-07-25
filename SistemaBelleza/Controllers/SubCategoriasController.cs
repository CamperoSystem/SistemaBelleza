using SistemaBelleza.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class SubCategoriasController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: SubCategorias
        public ActionResult Index()
        {
            var subcategorias = db.subcategorias.Include(s => s.categoria).ToList();
            return View("~/Views/SubCategorias/SubcategoriaL.cshtml", subcategorias);
        }

        // GET: SubCategorias/Crear
        public ActionResult Crear()
        {
            ViewBag.id_categoria = new SelectList(db.categorias, "id_categoria", "nombre_categoria");
            return View("~/Views/SubCategorias/SubcategoriaC.cshtml");
        }

        // POST: SubCategorias/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.subcategorias.Add(subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categorias, "id_categoria", "nombre_categoria", subcategoria.id_categoria);
            return View("~/Views/SubCategorias/SubcategoriaC.cshtml", subcategoria);
        }

        // GET: SubCategorias/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var subcategoria = db.subcategorias.Find(id);
            if (subcategoria == null)
                return HttpNotFound();

            ViewBag.id_categoria = new SelectList(db.categorias, "id_categoria", "nombre_categoria", subcategoria.id_categoria);
            return View("~/Views/SubCategorias/SubcategoriaE.cshtml", subcategoria);
        }

        // POST: SubCategorias/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(subcategoria model)
        {
            if (ModelState.IsValid)
            {
                var subcategoriaExistente = db.subcategorias.Find(model.id_subcategoria);
                if (subcategoriaExistente != null)
                {
                    subcategoriaExistente.nombre_subcategoria = model.nombre_subcategoria;
                    subcategoriaExistente.descripcion = model.descripcion;
                    subcategoriaExistente.id_categoria = model.id_categoria;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.id_categoria = new SelectList(db.categorias, "id_categoria", "nombre_categoria", model.id_categoria);
            return View("~/Views/SubCategorias/SubcategoriaE.cshtml", model);
        }

        // GET: SubCategorias/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var subcategoria = db.subcategorias
                .Include(s => s.categoria)
                .FirstOrDefault(s => s.id_subcategoria == id);

            if (subcategoria == null)
                return HttpNotFound();

            return View("~/Views/SubCategorias/SubcategoriaB.cshtml", subcategoria);
        }

        // POST: SubCategorias/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var subcategoria = db.subcategorias.Find(id);
            if (subcategoria != null)
            {
                db.subcategorias.Remove(subcategoria);
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
