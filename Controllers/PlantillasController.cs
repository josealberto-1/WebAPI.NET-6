using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCorePlantillas.Models;

namespace WebApiPlantillas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillasController : ControllerBase
    {
        private readonly CartaSolicitudContext _context;

        public PlantillasController(CartaSolicitudContext context)
        {
            _context = context;
        }

        // GET: api/Plantillas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plantilla>>> GetPlantillas()
        {
          if (_context.Plantillas == null)
          {
              return NotFound();
          }
            return await _context.Plantillas.ToListAsync();
        }

        // GET: api/Plantillas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plantilla>> GetPlantilla(int id)
        {
          if (_context.Plantillas == null)
          {
              return NotFound();
          }
            var plantilla = await _context.Plantillas.FindAsync(id);

            if (plantilla == null)
            {
                return NotFound();
            }

            return plantilla;
        }

        // PUT: api/Plantillas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantilla(int id, Plantilla plantilla)
        {
            if (id != plantilla.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantillaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Plantillas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plantilla>> PostPlantilla(Plantilla plantilla)
        {
          if (_context.Plantillas == null)
          {
              return Problem("Entity set 'CartaSolicitudContext.Plantillas'  is null.");
          }
            _context.Plantillas.Add(plantilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantilla", new { id = plantilla.Id }, plantilla);
        }

        // DELETE: api/Plantillas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantilla(int id)
        {
            if (_context.Plantillas == null)
            {
                return NotFound();
            }
            var plantilla = await _context.Plantillas.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            _context.Plantillas.Remove(plantilla);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PlantillaExists(int id)
        {
            return (_context.Plantillas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
