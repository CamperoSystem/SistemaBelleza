// Models/ReporteViewModel.cs
using System.Collections.Generic;

namespace SistemaBelleza.Models
{
    public class ReporteViewModel
    {
        public string TituloReporte { get; set; }
        public List<producto> Productos { get; set; }
        public List<usuario> Usuarios { get; set; }
        public List<ordene> Ordenes { get; set; }
        public List<marca> Marcas { get; set; }
        public string Mensaje { get; set; }
    }
}
