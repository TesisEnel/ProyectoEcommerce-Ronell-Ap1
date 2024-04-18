using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ProyectoEcommerceAP1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Clientes> Clientes { get; set;}

        public DbSet<TelefonosClientes> TelefonosClientes { get; set; } = default!;

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Carrito> Carrito { get; set; }

        public DbSet<ItemCarrito> ItemsCarrito { get; set; }








        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TelefonosClientes>().HasData(new List<TelefonosClientes>()
            {
                new TelefonosClientes(){
                    TipoTelId = 1, TipoTelefonos ="Telefono Local"
                },

                new TelefonosClientes(){
                    TipoTelId = 2, TipoTelefonos = "Celular"
                },

                new TelefonosClientes(){
                    TipoTelId = 3, TipoTelefonos = "Trabajo"
                },

                new TelefonosClientes(){
                    TipoTelId = 4, TipoTelefonos ="Persona Auxiliar"
                }
            });
        }
    }
}
