using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBelleza.Models
{
    // Asociamos esta clase parcial a la clase generada automáticamente por EF
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class usuario
    {
        // Vacío, pero permite asociar los metadatos sin tocar el archivo generado por EF
    }

    // Metadatos para validaciones y etiquetas
    public class UsuarioMetadata
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre completo")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }

        // NOTA: No marcamos como Required para permitir dejarla en blanco al editar
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La contraseña debe tener al menos 3 caracteres")]
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime? fecha_registro { get; set; }

        [Required(ErrorMessage = "Debe ingresar el rol del usuario")]
        [Display(Name = "Rol")]
        public string rol { get; set; }
    }
}
