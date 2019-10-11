using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudCore.Models;

namespace CrudCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly Db_PersonajesContext _context;

        public PersonajesController(Db_PersonajesContext context)
        {
            _context = context;
        }

        // GET: api/Personajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPersonajes>>> GetTbPersonajes()
        {
            return await _context.TbPersonajes.ToListAsync();
        }

        // GET: api/Personajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPersonajes>> GetTbPersonajes(int id)
        {
            var tbPersonajes = await _context.TbPersonajes.FindAsync(id);

            if (tbPersonajes == null)
            {
                return NotFound();
            }

            return tbPersonajes;
        }

        // PUT: api/Personajes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPersonajes(int id, TbPersonajes tbPersonajes)
        {
            if (id != tbPersonajes.IdPersonaje)
            {
                return BadRequest();
            }

            _context.Entry(tbPersonajes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPersonajesExists(id))
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

        // POST: api/Personajes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TbPersonajes>> PostTbPersonajes(TbPersonajes tbPersonajes)
        {
            _context.TbPersonajes.Add(tbPersonajes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPersonajes", new { id = tbPersonajes.IdPersonaje }, tbPersonajes);
        }

        // DELETE: api/Personajes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbPersonajes>> DeleteTbPersonajes(int id)
        {
            var tbPersonajes = await _context.TbPersonajes.FindAsync(id);
            if (tbPersonajes == null)
            {
                return NotFound();
            }

            _context.TbPersonajes.Remove(tbPersonajes);
            await _context.SaveChangesAsync();

            return tbPersonajes;
        }

        private bool TbPersonajesExists(int id)
        {
            return _context.TbPersonajes.Any(e => e.IdPersonaje == id);
        }
    }
}
