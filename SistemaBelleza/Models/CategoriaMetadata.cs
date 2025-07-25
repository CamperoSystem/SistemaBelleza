using System.ComponentModel.DataAnnotations;

namespace SistemaBelleza.Models
{
    // Asociación del modelo parcial con los metadatos
    [MetadataType(typeof(CategoriaMetadata))]
    public partial class categoria
    {
        // Esta clase se enlaza con el modelo generado por Entity Framework (EF)
    }

    // Metadatos para validación y etiquetas amigables
    public class CategoriaMetadata
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        [Display(Name = "Nombre de Categoría")]
        public string nombre_categoria { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
    }
}
