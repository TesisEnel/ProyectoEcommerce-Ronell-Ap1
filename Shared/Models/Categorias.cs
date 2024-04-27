using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El {0} no puede contener números")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres")]
        public string NombreCategoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[^\d\s]+$", ErrorMessage = "La {0} no puede contener numeros ni espacios en blanco")]
        public string Url { get; set; }
    }
}
