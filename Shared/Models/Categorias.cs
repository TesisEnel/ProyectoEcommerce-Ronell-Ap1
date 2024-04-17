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
        public string NombreCategoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Url { get; set; }
    }
}
