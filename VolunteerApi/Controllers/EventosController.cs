using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolunteerApi.DTOs;
using VolunteerApi.Models;

namespace VolunteerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<IActionResult> GetEventos()
        {
            var eventos = await _context.Eventos
                .Include(e => e.Organizador)  // Asegúrate de incluir el organizador
                .Include(e => e.Voluntarios)  // Si también necesitas los voluntarios
                .Select(e => new EventoDTO
                {
                    EventoId = e.EventoId,
                    NombreEvento = e.NombreEvento,
                    Fecha = e.Fecha,
                    Ubicacion = e.Ubicacion,
                    Descripcion = e.Descripcion,
                    Organizador = e.Organizador == null ? null : new UsuarioCreateDTO
                    {
                        UsuarioId = e.Organizador.UsuarioId,
                        Nombre = e.Organizador.Nombre,
                        Apellido = e.Organizador.Apellido,
                        Email = e.Organizador.Email,
                        RolId = e.Organizador.RolId
                    },
                    Voluntarios = e.Voluntarios.Select(v => new VoluntarioDTO
                    {
                        VoluntarioId = v.VoluntarioId,
                        Sexo = v.Sexo,
                        Domicilio = v.Domicilio,
                        NumeroCelular = v.NumeroCelular,
                        Especialidad = v.Especialidad!.NombreEspecialidad
                    }).ToList()
                })
                .ToListAsync();

            return Ok(eventos);
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.EventoId)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        [HttpPost("crear")]
        public async Task<IActionResult> CrearEvento([FromBody] EventoCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoEvento = new Evento
            {
                NombreEvento = dto.NombreEvento,
                Fecha = dto.Fecha,
                Ubicacion = dto.Ubicacion,
                Descripcion = dto.Descripcion,
                OrganizadorId = dto.OrganizadorId
            };

            _context.Eventos.Add(nuevoEvento);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Evento creado exitosamente", eventoId = nuevoEvento.EventoId });
        }




        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.EventoId }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.EventoId == id);
        }
    }
}
