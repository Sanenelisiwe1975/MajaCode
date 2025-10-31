using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeighborhoodAPI.Data;
using NeighborhoodAPI.Models;

namespace NeighborhoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly NeighborhoodDbContext _context;

        public NeighborhoodController(NeighborhoodDbContext context)
        {
            _context = context;
        }

        // GET: api/neighborhood
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Neighborhood>>> GetAll()
        {
            var neighborhoods = await _context.Neighborhoods.ToListAsync();
            return Ok(neighborhoods);
        }

        // GET: api/neighborhood/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Neighborhood>> GetById(int id)
        {
            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
                return NotFound();

            return Ok(neighborhood);
        }

        // POST: api/neighborhood
        [HttpPost]
        public async Task<ActionResult<Neighborhood>> Create(Neighborhood neighborhood)
        {
            _context.Neighborhoods.Add(neighborhood);
            await _context.SaveChangesAsync();

            // Return created neighborhood (includes computed TotalScore)
            return CreatedAtAction(nameof(GetById), new { id = neighborhood.Id }, neighborhood);
        }

        // PUT: api/neighborhood/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Neighborhood updated)
        {
            if (id != updated.Id)
                return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/neighborhood/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
                return NotFound();

            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
