using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAll();

        Cinema GetById(int id);

        void Add(Cinema cinema);

        Cinema Update(int id,  Cinema newCinema);

        void Delete(int id);
    }
}
