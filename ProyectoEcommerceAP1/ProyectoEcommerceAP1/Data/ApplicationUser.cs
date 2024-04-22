using Microsoft.AspNetCore.Identity;
using Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProyectoEcommerceAP1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string NombreCliente { get; set; } = string.Empty;

        public string ApellidoCliente {  get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = DateTime.Now.AddYears(-20);

        public string NumeroCedula { get; set; } = string.Empty;

    }

}
