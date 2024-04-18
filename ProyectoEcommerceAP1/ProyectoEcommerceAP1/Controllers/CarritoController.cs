using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEcommerceAP1.Data;
using Shared.Models;

namespace ProyectoEcommerceAP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Carrito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrito>>> GetCarrito()
        {
            return await _context.Carrito.ToListAsync();
        }

        // GET: api/Carrito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrito>> GetCarrito(int id)
        {
            if(_context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                            .Where(car => car.CarritoId == id)
                            .FirstOrDefaultAsync();

            if(carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        // PUT: api/Carrito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(int id, Carrito carrito)
        {
            if (id != carrito.CarritoId)
            {
                return BadRequest();
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carrito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrito>> PostCarrito(Carrito carrito)
        {
            try
            {
                // Asegúrate de cargar el cliente desde la base de datos
                var cliente = await _context.Clientes.FindAsync(carrito.ClienteId);
                if (cliente == null)
                {
                    return BadRequest("El cliente especificado no existe.");
                }

                // Asigna el cliente al carrito
                carrito.Cliente = cliente;

                // Agrega los elementos del carrito
                foreach (var item in carrito.Items)
                {
                    var producto = await _context.Productos.FindAsync(item.ProductoId);
                    if (producto == null)
                    {
                        return BadRequest($"El producto con ID {item.ProductoId} no existe.");
                    }
                    item.Producto = producto;
                    // Calcula el subtotal del item (si es necesario)
                }

                // Agrega el carrito a la base de datos
                _context.Carrito.Add(carrito);
                await _context.SaveChangesAsync();

                return Ok(carrito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al procesar la solicitud: {ex.Message}");
            }
        }

        // DELETE: api/Carrito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrito(int id)
        {
            if(_context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.CarritoId == id);
        }
    }
}
