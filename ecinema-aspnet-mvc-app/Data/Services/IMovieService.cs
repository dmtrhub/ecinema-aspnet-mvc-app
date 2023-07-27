using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();

        Movie GetById(int id);

        void Add(Movie movie);

        Movie Update(int id, Movie newMovie);

        void Delete(int id);
    }
}
