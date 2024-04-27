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

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Productos Producto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La {0} debe de ser mayor que 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El {0} debe de ser mayor o igual a cero")]
        public decimal SubTotal {  get; set; }


        public Carrito? Carrito { get; set; }
    }
}
