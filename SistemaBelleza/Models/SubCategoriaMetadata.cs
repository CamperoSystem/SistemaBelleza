using System.ComponentModel.DataAnnotations;

namespace SistemaBelleza.Models
{
    // Asociación del modelo parcial con los metadatos
    [MetadataType(typeof(SubCategoriaMetadata))]
    public partial class subcategoria
    {
        // Esta clase se enlaza con el modelo generado por Entity Framework (EF)
    }

    // Metadatos para validación y etiquetas amigables
    public class SubCategoriaMetadata
    {
        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        [Display(Name = "Categoría")]
        public int id_categoria { get; set; }

        [Required(ErrorMessage = "El nombre de la subcategoría es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        [Display(Name = "Nombre de Subcategoría")]
        public string nombre_subcategoria { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
    }
}
