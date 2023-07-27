using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _context.Movies.Include(c => c.Cinema).ToListAsync();
            return movies;
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Update(int id, Movie newMovie)
        {
            throw new NotImplementedException();
        }
    }
}
