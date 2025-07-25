using SistemaBelleza;
using SistemaBelleza.Models;
using System.Linq;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class ControladorAccesoController : Controller
    {
        tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        // GET: Iniciar sesión
        public ActionResult IniciarSesion()
        {
            return View();
        }

        // POST: Procesar inicio de sesión
        [HttpPost]
        public ActionResult IniciarSesion(string correo, string contraseña)
        {
            var admin = db.usuarios
                          .FirstOrDefault(u => u.correo == correo && u.contraseña == contraseña && u.rol == "admin");

            if (admin != null)
            {
                Session["usuario"] = admin.nombre; // Aquí usamos "usuario"
                return RedirectToAction("Dashboard", "PanelAdmin");
            }
            else
            {
                ViewBag.Error = "Correo o contraseña incorrectos";
                return View();
            }
        }

        // Cerrar sesión
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion");
        }
    }
}
