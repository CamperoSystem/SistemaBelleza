using System.ComponentModel.DataAnnotations;

namespace SistemaBelleza.Models
{
    // Asociamos esta clase parcial a la clase generada automáticamente por EF
    [MetadataType(typeof(MarcaMetadata))]
    public partial class marca
    {
        // Vacío, solo para enlazar metadatos sin modificar el archivo generado por EF
    }

    // Metadatos para validaciones y etiquetas
    public class MarcaMetadata
    {
        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        [Display(Name = "Nombre de Marca")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
    }
}
