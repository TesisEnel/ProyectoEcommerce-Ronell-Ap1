using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEcommerceAP1.Data;
using ProyectoEcommerceAP1.Data;
using Shared.Models;

namespace ProyectoEcommerceAP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;


        public CarritoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
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
            if (_context.Carrito == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                            .Where(car => car.CarritoId == id)
                            .FirstOrDefaultAsync();

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }


        [HttpGet("Items/{userId}")]
        public async Task<ActionResult<List<ItemCarrito>>> GetItemsCarritoByUserId(string userId)
        {
            try
            {
                var detallesCarrito = await _context.ItemsCarrito.Where(ic => ic.Carrito.UserId == userId).ToListAsync();
                return Ok(detallesCarrito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los detalles del carrito: {ex.Message}");
            }
        }



        [HttpGet("Usuario/{userId}")]
        public async Task<ActionResult<Carrito>> GetCarritoUsuario(string userId)
        {
            try
            {
                var carrito = await _context.Carrito
                                    .Include(c => c.Items)
                                    .ThenInclude(ic => ic.Producto)
                                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (carrito == null)
                {
                    var existingCarrito = await _context.Carrito.FirstOrDefaultAsync(c => c.UserId == userId);

                    if (existingCarrito != null)
                    {
                        return existingCarrito;
                    }
                    carrito = new Carrito { UserId = userId, Items = new List<ItemCarrito>() };
                    _context.Carrito.Add(carrito);
                    await _context.SaveChangesAsync();
                }

                return carrito;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el carrito del usuario: {ex.Message}");
            }
        }


        [HttpGet("EnCarrito/{userId}")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductosEnCarrito(string userId)
        {
            try
            {
                var productosEnCarrito = await (from p in _context.Productos
                                                join ic in _context.ItemsCarrito on p.ProductoId equals ic.ProductoId
                                                join c in _context.Carrito on ic.Carrito.CarritoId equals c.CarritoId
                                                where c.UserId == userId
                                                select p).ToListAsync();

                return Ok(productosEnCarrito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener productos en el carrito: {ex.Message}");
            }
        }



        [HttpGet("Producto/{productoId}")]
        public async Task<ActionResult<ItemCarrito>> GetItemCarritoByProductoId(int productoId)
        {
            try
            {
                var itemCarrito = await _context.ItemsCarrito.FirstOrDefaultAsync(ic => ic.ProductoId == productoId);

                
                if (itemCarrito == null)
                {
                    return NotFound($"No se encontró un ítem de carrito asociado al producto con ID {productoId}.");
                }

                return itemCarrito;
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Error al obtener el ítem de carrito asociado al producto con ID {productoId}: {ex.Message}");
            }
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

        [HttpPost]
        public async Task<ActionResult<Carrito>> PostCarrito(Carrito carrito)
        {
            try
            {
                var user = await userManager.FindByIdAsync(carrito.UserId);
                if (user == null)
                {
                    return BadRequest("El usuario especificado no existe.");
                }

                var carritoExistente = await _context.Carrito.FirstOrDefaultAsync(c => c.UserId == carrito.UserId);
                if (carritoExistente != null)
                {
                    foreach (var item in carrito.Items)
                    {
                        var producto = await _context.Productos.FindAsync(item.ProductoId);
                        if (producto == null)
                        {
                            return BadRequest($"El producto con ID {item.ProductoId} no existe.");
                        }
                        item.Producto = producto;
                        carritoExistente.Items.Add(item);
                    }

                    await _context.SaveChangesAsync();
                    return Ok(carritoExistente);
                }
                else
                {
                    carrito.UserId = user.Id;

                    foreach (var item in carrito.Items)
                    {
                        var producto = await _context.Productos.FindAsync(item.ProductoId);
                        if (producto == null)
                        {
                            return BadRequest($"El producto con ID {item.ProductoId} no existe.");
                        }

                        item.Producto = producto;
                    }

                    _context.Carrito.Add(carrito);
                    await _context.SaveChangesAsync();

                    return Ok(carrito);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al procesar la solicitud: {ex.Message}");
            }
        }


        [HttpPost("{carritoId}/Items")]
        public async Task<ActionResult<ItemCarrito>> PostItemCarrito(int carritoId, ItemCarrito itemCarrito)
        {
            try
            {
                var carrito = await _context.Carrito.FindAsync(carritoId);
                if (carrito == null)
                {
                    return NotFound($"No se encontró un carrito con ID {carritoId}.");
                }

                var producto = await _context.Productos.FindAsync(itemCarrito.ProductoId);
                if (producto == null)
                {
                    return BadRequest($"El producto con ID {itemCarrito.ProductoId} no existe.");
                }
                itemCarrito.Carrito = carrito;

                itemCarrito.Producto = producto;

                _context.ItemsCarrito.Add(itemCarrito);
                await _context.SaveChangesAsync();

                return Ok(itemCarrito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error al agregar el ítem al carrito: {ex.Message}");
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


        [HttpDelete("EliminarDetalle/{detalleId}")]
        public async Task<IActionResult> DeleteDetalles(int detalleId)
        {
            if (detalleId < 0)
            {
                return BadRequest();
            }

            var detalle = await _context.ItemsCarrito.FirstOrDefaultAsync(e => e.ItemCarritoId == detalleId);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.ItemsCarrito.Remove(detalle);
            await _context.SaveChangesAsync();

            return Ok(detalleId);
        }


        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.CarritoId == id);
        }
    }
}
