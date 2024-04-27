using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.Models
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }


        public string UserId { get; set; } = string.Empty;


        public ICollection<ItemCarrito> Items { get; set; } = new List<ItemCarrito>();

        public decimal Total { get; set; }
    }
}
