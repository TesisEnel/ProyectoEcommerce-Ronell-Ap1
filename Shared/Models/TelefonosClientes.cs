using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TelefonosClientes
    {
        [Key]
        public int TipoTelId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoTelefonos { get; set; } = string.Empty;
    }
}
