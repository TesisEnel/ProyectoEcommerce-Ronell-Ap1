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
    public class ItemCarritoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemCarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemCarritoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCarrito>>> GetItemsCarrito()
        {
            return await _context.ItemsCarrito.ToListAsync();
        }

        // GET: api/ItemCarritoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCarrito>> GetItemCarrito(int id)
        {
            if(_context.ItemsCarrito == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.ItemsCarrito
                                .Where(itemCar => itemCar.ItemCarritoId == id)
                                .FirstOrDefaultAsync();

            if (itemCarrito == null)
            {
                return NotFound();
            }

            return itemCarrito;
        }

        // PUT: api/ItemCarritoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCarrito(int id, ItemCarrito itemCarrito)
        {
            if (id != itemCarrito.ItemCarritoId)
            {
                return BadRequest();
            }

            _context.Entry(itemCarrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCarritoExists(id))
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

        // POST: api/ItemCarritoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemCarrito>> PostItemCarrito(ItemCarrito itemCarrito)
        {
            if (!ItemCarritoExists(itemCarrito.ItemCarritoId))
            {
                _context.ItemsCarrito.Add(itemCarrito);
            }
            else
            {
                _context.ItemsCarrito.Update(itemCarrito);
            }

            await _context.SaveChangesAsync();

            return Ok(itemCarrito);
        }

        // DELETE: api/ItemCarritoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemCarrito(int id)
        {
            if(_context.ItemsCarrito == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.ItemsCarrito.FindAsync(id);
            if (itemCarrito == null)
            {
                return NotFound();
            }

            _context.ItemsCarrito.Remove(itemCarrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemCarritoExists(int id)
        {
            return _context.ItemsCarrito.Any(e => e.ItemCarritoId == id);
        }
    }
}
