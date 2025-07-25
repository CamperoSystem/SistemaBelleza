using System.ComponentModel.DataAnnotations;

namespace SistemaBelleza.Models
{
    // Asociación del modelo parcial con los metadatos
    [MetadataType(typeof(ProductosMetadata))]
    public partial class producto
    {
        // Esta clase se enlaza con el modelo generado por Entity Framework (EF)
    }

    // Metadatos para validación y etiquetas amigables
    public class ProductosMetadata
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre del Producto")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor que 0")]
        [Display(Name = "Precio (Bs)")]
        public decimal precio { get; set; }

        [Display(Name = "Stock Disponible")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int? stock { get; set; }

        [Display(Name = "Imagen (URL o nombre de archivo)")]
        [StringLength(255, ErrorMessage = "El nombre de la imagen no puede tener más de 255 caracteres")]
        public string imagen { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una subcategoría")]
        [Display(Name = "Subcategoría")]
        public int? id_subcategoria { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una marca")]
        [Display(Name = "Marca")]
        public int? id_marca { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de producto")]
        [Display(Name = "Tipo de Producto")]
        public string tipo_producto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        [Display(Name = "Género")]
        public string genero { get; set; }
    }
}
