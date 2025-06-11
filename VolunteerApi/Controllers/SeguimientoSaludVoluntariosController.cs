using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolunteerApi.Models;

namespace VolunteerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoSaludVoluntariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeguimientoSaludVoluntariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SeguimientoSaludVoluntarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguimientoSaludVoluntario>>> GetSeguimientos()
        {
            return await _context.SeguimientoSaludVoluntarios.ToListAsync();
        }

        // GET: api/SeguimientoSaludVoluntarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeguimientoSaludVoluntario>> GetSeguimiento(int id)
        {
            var seguimiento = await _context.SeguimientoSaludVoluntarios.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            return seguimiento;
        }

        // POST: api/SeguimientoSaludVoluntarios
        [HttpPost]
        public async Task<ActionResult<SeguimientoSaludVoluntario>> CreateSeguimiento(SeguimientoSaludVoluntario seguimiento)
        {
            _context.SeguimientoSaludVoluntarios.Add(seguimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeguimiento), new { id = seguimiento.SeguimientoID }, seguimiento);
        }

        // PUT: api/SeguimientoSaludVoluntarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeguimiento(int id, SeguimientoSaludVoluntario seguimiento)
        {
            if (id != seguimiento.SeguimientoID)
            {
                return BadRequest();
            }

            _context.Entry(seguimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SeguimientoSaludVoluntarios.Any(e => e.SeguimientoID == id))
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

        // DELETE: api/SeguimientoSaludVoluntarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguimiento(int id)
        {
            var seguimiento = await _context.SeguimientoSaludVoluntarios.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            _context.SeguimientoSaludVoluntarios.Remove(seguimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
