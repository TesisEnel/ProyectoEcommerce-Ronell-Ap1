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
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telefono { get; set; } = string.Empty;
    }
}
