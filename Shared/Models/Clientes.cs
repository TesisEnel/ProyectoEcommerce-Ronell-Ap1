using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = DateTime.Now.AddYears(-20);


        [ForeignKey("ClienteId")]
        public ICollection<ClientesDetalle> ClientesDetalle { get; set; } = new List<ClientesDetalle>();
    }
}
