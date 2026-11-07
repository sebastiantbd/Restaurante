using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeloRestaurante.Entidades;
using BackRestaurante.Data;

[Route("api/[controller]")]
[ApiController]
public class ChefsController : ControllerBase
{
    private readonly DataContext _context;
    public ChefsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/Chef
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Chef>>> GetChef()
    {
        return await _context.Chefs.ToListAsync();
    }

    // GET: api/Chef/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Chef>> GetChef(int id)
    {
        var chef = await _context.Chefs.FindAsync(id);

        if (chef == null)
        {
            return NotFound();
        }

        return chef;
    }

    // PUT: api/Chef/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutChef(int? id, Chef chef)
    {
        if (id != chef.Id)
        {
            return BadRequest();
        }

        _context.Entry(chef).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ChefExists(id))
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

    // POST: api/Chef
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Chef>> PostChef(Chef chef)
    {
        _context.Chefs.Add(chef);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetChef", new { id = chef.Id }, chef);
    }

    // DELETE: api/Chef/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChef(int? id)
    {
        var chef = await _context.Chefs.FindAsync(id);
        if (chef == null)
        {
            return NotFound();
        }

        _context.Chefs.Remove(chef);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ChefExists(int? id)
    {
        return _context.Chefs.Any(e => e.Id == id);
    }
}
