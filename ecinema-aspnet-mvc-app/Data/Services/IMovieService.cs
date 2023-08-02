using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Data.ViewModels;
using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie> 
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdowns();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
