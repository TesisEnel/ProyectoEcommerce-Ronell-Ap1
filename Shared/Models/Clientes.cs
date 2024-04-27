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

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El {0} no puede contener números")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [FechaNacimientoValidaCliente(15, 105, ErrorMessage = "La Fecha de nacimiento debe ser mayor o igual a 15 años y menor que 105 años.")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now.AddYears(-20);


        [ForeignKey("ClienteId")]
        public ICollection<ClientesDetalle> ClientesDetalle { get; set; } = new List<ClientesDetalle>();
    }



    public class FechaNacimientoValidaCliente : ValidationAttribute
    {
        private readonly int edadMinima;
        private readonly int edadMaxima;

        public FechaNacimientoValidaCliente(int edadMinima, int edadMaxima)
        {
            this.edadMinima = edadMinima;
            this.edadMaxima = edadMaxima;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fechaNacimiento = Convert.ToDateTime(value);
                int edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (fechaNacimiento > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                if (edad < edadMinima || edad >= edadMaxima)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
