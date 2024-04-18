using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ItemCarrito
    {
        [Key]
        public int ItemCarritoId { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Productos Producto { get; set; }

        public int Cantidad { get; set; }

        public float SubTotal {  get; set; }
    }
}
