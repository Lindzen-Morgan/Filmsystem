using Filmsystemet4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Add using statement for LINQ

namespace Filmsystemet4.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieRating([FromBody] MovieRating rating)
        {
            if (ModelState.IsValid)
            {
                _context.MovieRatings.Add(rating);
                await _context.SaveChangesAsync();
                return Ok(rating);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("ratings/{personId}")]
        public async Task<IActionResult> GetMovieRatings(int personId)
        {
            var ratings = await _context.MovieRatings
                .Where(r => r.UserId == personId.ToString()) // Convert personId to string for comparison
                .ToListAsync();
            return Ok(ratings);
        }

    }
}
