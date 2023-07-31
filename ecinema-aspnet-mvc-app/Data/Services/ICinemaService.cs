using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();

        Task<Cinema> GetByIdAsync(int id);

        Task AddAsync(Cinema cinema);

        Task<Cinema> UpdateAsync(int id,  Cinema newCinema);

        Task DeleteAsync(int id);
    }
}
