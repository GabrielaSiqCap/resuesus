using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resuesus.Data;
using resuesus.Models;

namespace resuesus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedeConhecidasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RedeConhecidasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RedeConhecidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RedeConhecida>>> GetRedeConhecidas()
        {
            return await _context.RedeConhecidas.ToListAsync();
        }

        // GET: api/RedeConhecidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RedeConhecida>> GetRedeConhecida(Guid id)
        {
            var redeConhecida = await _context.RedeConhecidas.FindAsync(id);

            if (redeConhecida == null)
            {
                return NotFound();
            }

            return redeConhecida;
        }

        // PUT: api/RedeConhecidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedeConhecida(Guid id, RedeConhecida redeConhecida)
        {
            if (id != redeConhecida.RedeConhecidaId)
            {
                return BadRequest();
            }

            _context.Entry(redeConhecida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedeConhecidaExists(id))
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

        // POST: api/RedeConhecidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RedeConhecida>> PostRedeConhecida(RedeConhecida redeConhecida)
        {
            _context.RedeConhecidas.Add(redeConhecida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedeConhecida", new { id = redeConhecida.RedeConhecidaId }, redeConhecida);
        }

        // DELETE: api/RedeConhecidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedeConhecida(Guid id)
        {
            var redeConhecida = await _context.RedeConhecidas.FindAsync(id);
            if (redeConhecida == null)
            {
                return NotFound();
            }

            _context.RedeConhecidas.Remove(redeConhecida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedeConhecidaExists(Guid id)
        {
            return _context.RedeConhecidas.Any(e => e.RedeConhecidaId == id);
        }
    }
}
