using Filmsystemet4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/movielinks")]
[ApiController]
public class MovieLinksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MovieLinksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/movielinks
    [HttpPost]
    public async Task<ActionResult<UserMovieLink>> PostMovieLink(UserMovieLink movieLink)
    {
        _context.UserMovieLinks.Add(movieLink);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetMovieLink", new { id = movieLink.Id }, movieLink);
    }

    // PUT: api/movielinks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovieLink(int id, UserMovieLink movieLink)
    {
        if (id != movieLink.Id)
        {
            return BadRequest();
        }

        _context.Entry(movieLink).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieLinkExists(id))
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

    // DELETE: api/movielinks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovieLink(int id)
    {
        var movieLink = await _context.UserMovieLinks.FindAsync(id);
        if (movieLink == null)
        {
            return NotFound();
        }

        _context.UserMovieLinks.Remove(movieLink);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MovieLinkExists(int id)
    {
        return _context.UserMovieLinks.Any(e => e.Id == id);
    }
    [HttpPost("create-link")]
    public IActionResult CreateMovieLink([FromBody] MovieGenreLink link)
    {
        if (ModelState.IsValid)
        {
            _context.MovieGenreLinks.Add(link);
            _context.SaveChanges();
            return Ok(link);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

}
