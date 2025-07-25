using SistemaBelleza.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class UsuariosController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.usuarios.ToList();
            return View("~/Views/Usuarios/UsuariosL.cshtml", usuarios);
        }

        // GET: Usuarios/Crear
        public ActionResult Crear()
        {
            return View("~/Views/Usuarios/UsuariosC.cshtml");
        }

        // POST: Usuarios/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Usuarios/UsuariosC.cshtml", usuario);
        }

        // GET: Usuarios/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var usuario = db.usuarios.Find(id);
            if (usuario == null)
                return HttpNotFound();

            return View("~/Views/Usuarios/UsuariosE.cshtml", usuario);
        }

        // POST: Usuarios/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = db.usuarios.Find(model.id_usuario);
                if (usuarioExistente != null)
                {
                    usuarioExistente.nombre = model.nombre;
                    usuarioExistente.correo = model.correo;
                    usuarioExistente.telefono = model.telefono;
                    usuarioExistente.rol = model.rol;
                    usuarioExistente.fecha_registro = model.fecha_registro;

                    // Solo actualiza la contraseña si el usuario ingresó una nueva
                    if (!string.IsNullOrWhiteSpace(model.contraseña))
                    {
                        usuarioExistente.contraseña = model.contraseña;
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("~/Views/Usuarios/UsuariosE.cshtml", model);
        }

        // GET: Usuarios/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var usuario = db.usuarios.Find(id);
            if (usuario == null)
                return HttpNotFound();

            return View("~/Views/Usuarios/UsuariosB.cshtml", usuario);
        }

        // POST: Usuarios/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            var usuario = db.usuarios.Find(id);
            if (usuario != null)
            {
                db.usuarios.Remove(usuario);
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
