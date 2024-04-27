using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ClientesDetalle
    {
        [Key]
        public int DetalleIdCliente { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [ForeignKey("TipoTelId")]
        public int TipoTelId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(70, MinimumLength =2, ErrorMessage = "El campo {0} debe de tener entre {2} y {1} caracteres")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El campo {0} no puede contener numeros")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Phone(ErrorMessage = "El campo {0} debe de ser un numero telefonico")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El campo {0} debe de tener el siguiente formato 'XXX-XXX-XXXX'")]
        public string Telefono { get; set; } = string.Empty;
    }
}
