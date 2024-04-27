using Microsoft.AspNetCore.Identity;
using Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProyectoEcommerceAP1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El {0} no puede contener números")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El {0} no puede contener numeros")]
        public string ApellidoCliente {  get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [FechaNacimientoValida(18, 105, ErrorMessage = "La Fecha de nacimiento debe ser mayor o igual a 18 años y menor que 105 años.")]
        public DateTime? FechaNacimiento { get; set; } = DateTime.Now.AddYears(-20);


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^\d{3}-\d{7}-\d$", ErrorMessage = "El {0} debe de tener el formato XXX-XXXXXXX-X")]
        public string NumeroCedula { get; set; } = string.Empty;

    }

    public class FechaNacimientoValida : ValidationAttribute
    {
        private readonly int edadMinima;
        private readonly int edadMaxima;

        public FechaNacimientoValida(int edadMinima, int edadMaxima)
        {
            this.edadMinima = edadMinima;
            this.edadMaxima = edadMaxima;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime fechaNacimiento = Convert.ToDateTime(value);
                int edad = DateTime.Today.Year - fechaNacimiento.Year;

                if(fechaNacimiento > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                if(edad < edadMinima || edad >= edadMaxima)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
