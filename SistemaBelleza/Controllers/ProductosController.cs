using SistemaBelleza.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class ProductosController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.productos
                .Include(p => p.subcategoria)
                .Include(p => p.marca)
                .ToList();

            return View("~/Views/Productos/ProductosL.cshtml", productos);
        }

        // GET: Productos/Crear
        public ActionResult Crear()
        {
            ViewBag.id_subcategoria = new SelectList(db.subcategorias.ToList(), "id_subcategoria", "nombre_subcategoria");
            ViewBag.id_marca = new SelectList(db.marcas.ToList(), "id_marca", "nombre");
            return View("~/Views/Productos/ProductosC.cshtml");
        }

        // POST: Productos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.productos.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            ViewBag.id_subcategoria = new SelectList(db.subcategorias.ToList(), "id_subcategoria", "nombre_subcategoria", producto.id_subcategoria);
            ViewBag.id_marca = new SelectList(db.marcas.ToList(), "id_marca", "nombre", producto.id_marca);
            return View("~/Views/Productos/ProductosC.cshtml", producto);
        }

        // GET: Productos/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.productos.Find(id);
            if (producto == null)
                return HttpNotFound();

            ViewBag.id_subcategoria = new SelectList(db.subcategorias.ToList(), "id_subcategoria", "nombre_subcategoria", producto.id_subcategoria);
            ViewBag.id_marca = new SelectList(db.marcas.ToList(), "id_marca", "nombre", producto.id_marca);
            return View("~/Views/Productos/ProductosE.cshtml", producto);
        }

        // POST: Productos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(producto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productoExistente = db.productos.Find(model.id_producto);
                    if (productoExistente != null)
                    {
                        productoExistente.nombre = model.nombre;
                        productoExistente.descripcion = model.descripcion;
                        productoExistente.precio = model.precio;
                        productoExistente.stock = model.stock;
                        productoExistente.imagen = model.imagen;
                        productoExistente.id_subcategoria = model.id_subcategoria;
                        productoExistente.id_marca = model.id_marca;
                        productoExistente.tipo_producto = model.tipo_producto;
                        productoExistente.genero = model.genero;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            ViewBag.id_subcategoria = new SelectList(db.subcategorias.ToList(), "id_subcategoria", "nombre_subcategoria", model.id_subcategoria);
            ViewBag.id_marca = new SelectList(db.marcas.ToList(), "id_marca", "nombre", model.id_marca);
            return View("~/Views/Productos/ProductosE.cshtml", model);
        }

        // GET: Productos/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.productos
                .Include(p => p.subcategoria)
                .Include(p => p.marca)
                .FirstOrDefault(p => p.id_producto == id);

            if (producto == null)
                return HttpNotFound();

            return View("~/Views/Productos/ProductosB.cshtml", producto);
        }

        // POST: Productos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var producto = db.productos.Find(id);
            if (producto != null)
            {
                db.productos.Remove(producto);
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
