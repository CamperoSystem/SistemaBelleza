using SistemaBelleza.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class MarcasController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: Marcas
        public ActionResult Index()
        {
            var marcas = db.marcas.ToList();
            return View("~/Views/Marcas/MarcaL.cshtml", marcas);
        }

        // GET: Marcas/Crear
        public ActionResult Crear()
        {
            return View("~/Views/Marcas/MarcaC.cshtml");
        }

        // POST: Marcas/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(marca marca)
        {
            if (ModelState.IsValid)
            {
                db.marcas.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Marcas/MarcaC.cshtml", marca);
        }

        // GET: Marcas/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var marca = db.marcas.Find(id);
            if (marca == null)
                return HttpNotFound();

            return View("~/Views/Marcas/MarcaE.cshtml", marca);
        }

        // POST: Marcas/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(marca model)
        {
            if (ModelState.IsValid)
            {
                var marcaExistente = db.marcas.Find(model.id_marca);
                if (marcaExistente != null)
                {
                    marcaExistente.nombre = model.nombre;
                    marcaExistente.descripcion = model.descripcion;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("~/Views/Marcas/MarcaE.cshtml", model);
        }

        // GET: Marcas/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var marca = db.marcas.Find(id);
            if (marca == null)
                return HttpNotFound();

            return View("~/Views/Marcas/MarcaB.cshtml", marca);
        }

        // POST: Marcas/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var marca = db.marcas.Find(id);
            if (marca != null)
            {
                db.marcas.Remove(marca);
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
