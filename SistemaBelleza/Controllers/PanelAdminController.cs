using System.Linq;
using System.Web.Mvc;
using SistemaBelleza.Models;

namespace SistemaBelleza.Controllers
{
    public class PanelAdminController : Controller
    {
        tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        public ActionResult Dashboard()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("IniciarSesion", "ControladorAcceso");
            }

            ViewBag.Usuario = Session["usuario"];
            ViewBag.TotalUsuarios = db.usuarios.Count();
            ViewBag.TotalProductos = db.productos.Count();
            ViewBag.TotalOrdenes = db.ordenes.Count();
            ViewBag.TotalClientes = db.usuarios.Count(u => u.rol == "cliente");
            ViewBag.TotalCategorias = db.categorias.Count();
            ViewBag.TotalMarcas = db.marcas.Count();
            ViewBag.ProductosSinStock = db.productos.Count(p => p.stock <= 0);
            ViewBag.TotalSubcategorias = db.subcategorias.Count(); // NUEVO

            return View();
        }
    }
}
