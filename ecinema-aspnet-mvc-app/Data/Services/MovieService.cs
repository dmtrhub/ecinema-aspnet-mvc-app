using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Data.ViewModels;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                PictureUrl = data.PictureUrl,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Category = data.Category,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Movie_Actors).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movie;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdowns()
        {
            var result = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return result;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var updated = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (updated != null)
            {
                updated.Title = data.Title;
                updated.Description = data.Description;
                updated.Price = data.Price;
                updated.PictureUrl = data.PictureUrl;
                updated.CinemaId = data.CinemaId;
                updated.StartDate = data.StartDate;
                updated.EndDate = data.EndDate;
                updated.Category = data.Category;
                updated.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var actors = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(actors);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActors = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActors);
            }
            await _context.SaveChangesAsync();
        }
    }
}
