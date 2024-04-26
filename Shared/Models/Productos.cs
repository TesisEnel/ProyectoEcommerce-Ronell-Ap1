using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; } = string.Empty;


        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public DateTime FechaEntrada { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CantidadProducto { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio"), DisplayName("Imagen del producto")]
        public string? ImagenProducto { get; set; }

        public decimal PrecioOferta {  get; set; }

        public bool EnCarrito { get; set; } = false;

        public int? ItemCarritoId { get; set; }
    }
}
