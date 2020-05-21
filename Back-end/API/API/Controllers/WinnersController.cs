using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnersController : ControllerBase
    {
        private readonly WinnerContext _context;

        public WinnersController(WinnerContext context)
        {
            _context = context;
        }

        // GET: api/Winners
        [HttpGet]
        public IEnumerable<Winner> GetWinners()
        {
            return _context.Winners;
        }

        // GET: api/Winners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWinner([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winner = await _context.Winners.FindAsync(id);

            if (winner == null)
            {
                return NotFound();
            }

            return Ok(winner);
        }

        // PUT: api/Winners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinner([FromRoute] long id, [FromBody] Winner winner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winner.Id)
            {
                return BadRequest();
            }

            _context.Entry(winner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinnerExists(id))
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

        // POST: api/Winners
        [HttpPost]
        public async Task<IActionResult> PostWinner([FromBody] Winner winner)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Winners.Add(winner);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetWinner", new { id = winner.Id }, winner);
            return CreatedAtAction(nameof(GetWinner), new { id = winner.Id }, winner);
        }

        // DELETE: api/Winners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinner([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var winner = await _context.Winners.FindAsync(id);
            if (winner == null)
            {
                return NotFound();
            }

            _context.Winners.Remove(winner);
            await _context.SaveChangesAsync();

            return Ok(winner);
        }

        private bool WinnerExists(long id)
        {
            return _context.Winners.Any(e => e.Id == id);
        }
    }
}