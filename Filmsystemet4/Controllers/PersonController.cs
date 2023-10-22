using Filmsystemet4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPeople()
    {
        var people = await _context.Persons.ToListAsync();
        return Ok(people);
    }
    [HttpGet("people")]
    public IActionResult GetAllPeople()
    {
        var people = _context.Persons.ToList(); // Fetch all people
        return Ok(people);
    }
    [HttpGet("genres/{personId}")]
    public IActionResult GetGenresForPerson(int personId)
    {
        var genres = _context.Genres.Where(g => g.GenreID == personId).ToList();
        return Ok(genres);
    }
    [HttpGet("movies/{personId}")]
    public IActionResult GetMoviesForPerson(int personId)
    {
        var movies = _context.Movies.Where(m => m.MovieID == personId).ToList();
        return Ok(movies);
    }
    [HttpPost("associateGenre")]
    public IActionResult AssociateGenreWithPerson([FromBody] Genre genre)
    {
        _context.Genres.Add(genre);
        _context.SaveChanges();
        return Ok(genre);
    }
    [HttpPost("addMovieLink")]
    public IActionResult AddMovieLink([FromBody] MovieGenreLink movieLink)
    {
        _context.MovieGenreLinks.Add(movieLink);
        _context.SaveChanges();
        return Ok(movieLink);
    }
   







}
