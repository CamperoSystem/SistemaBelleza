// Controllers/ReportesController.cs
using SistemaBelleza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SistemaBelleza.Controllers
{
    public class ReportesController : Controller
    {
        private tienda_bellezaEntities1 db = new tienda_bellezaEntities1();

        public ActionResult Index()
        {
            ViewBag.Tipo = "";
            ViewBag.TituloReporte = "";
            return View("~/Views/Reportes/ReportesL.cshtml", new object());
        }

        [HttpPost]
        public ActionResult Filtrar(string tipo)
        {
            ViewBag.Tipo = tipo;

            switch (tipo)
            {
                case "productos":
                    ViewBag.TituloReporte = "Reporte de Productos";
                    var productos = db.productos.ToList();
                    return View("~/Views/Reportes/ReportesL.cshtml", productos);

                case "usuarios":
                    ViewBag.TituloReporte = "Reporte de Usuarios";
                    var usuarios = db.usuarios.ToList();
                    return View("~/Views/Reportes/ReportesL.cshtml", usuarios);

                case "ordenes":
                    ViewBag.TituloReporte = "Reporte de Órdenes";
                    var ordenes = db.ordenes.ToList();
                    return View("~/Views/Reportes/ReportesL.cshtml", ordenes);

                case "marcas":
                    ViewBag.TituloReporte = "Reporte de Marcas";
                    var marcas = db.marcas.ToList();
                    return View("~/Views/Reportes/ReportesL.cshtml", marcas);

                default:
                    ViewBag.Mensaje = "Seleccione un tipo de reporte válido.";
                    return View("~/Views/Reportes/ReportesL.cshtml", new object());
            }
        }
    }
}
