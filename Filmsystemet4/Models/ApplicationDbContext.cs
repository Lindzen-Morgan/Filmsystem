using Microsoft.EntityFrameworkCore;

namespace Filmsystemet4.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for your custom models
        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenreLink> MovieGenreLinks { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<UserMovieLink> UserMovieLinks { get; set; }
    }
}
