using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Data;
using InventarioApi.Models;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlmacensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Almacens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacen>>> GetAlmacen()
        {
            return await _context.Almacen.ToListAsync();
        }

        // GET: api/Almacens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Almacen>> GetAlmacen(string id)
        {
            var almacen = await _context.Almacen.FindAsync(id);

            if (almacen == null)
            {
                return NotFound();
            }

            return almacen;
        }

        // PUT: api/Almacens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(string id, Almacen almacen)
        {
            if (id != almacen.Producto)
            {
                return BadRequest();
            }

            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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

        // POST: api/Almacens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Almacen>> PostAlmacen(Almacen almacen)
        {
            _context.Almacen.Add(almacen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlmacenExists(almacen.Producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlmacen", new { id = almacen.Producto }, almacen);
        }

        // DELETE: api/Almacens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(string id)
        {
            var almacen = await _context.Almacen.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }

            _context.Almacen.Remove(almacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlmacenExists(string id)
        {
            return _context.Almacen.Any(e => e.Producto == id);
        }
    }
}
