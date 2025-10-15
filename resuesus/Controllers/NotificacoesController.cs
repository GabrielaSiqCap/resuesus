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
    public class NotificacoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public NotificacoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Notificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacoes>>> GetNotificacoes()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        // GET: api/Notificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacoes>> GetNotificacoes(Guid id)
        {
            var notificacoes = await _context.Notificacoes.FindAsync(id);

            if (notificacoes == null)
            {
                return NotFound();
            }

            return notificacoes;
        }

        // PUT: api/Notificacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacoes(Guid id, Notificacoes notificacoes)
        {
            if (id != notificacoes.NotificacoesId)
            {
                return BadRequest();
            }

            _context.Entry(notificacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacoesExists(id))
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

        // POST: api/Notificacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notificacoes>> PostNotificacoes(Notificacoes notificacoes)
        {
            _context.Notificacoes.Add(notificacoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacoes", new { id = notificacoes.NotificacoesId }, notificacoes);
        }

        // DELETE: api/Notificacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacoes(Guid id)
        {
            var notificacoes = await _context.Notificacoes.FindAsync(id);
            if (notificacoes == null)
            {
                return NotFound();
            }

            _context.Notificacoes.Remove(notificacoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacoesExists(Guid id)
        {
            return _context.Notificacoes.Any(e => e.NotificacoesId == id);
        }
    }
}
