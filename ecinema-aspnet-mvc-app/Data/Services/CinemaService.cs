using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDbContext _context;

        public CinemaService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetAll()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return cinemas;
        }

        public Cinema GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cinema Update(int id, Cinema newCinema)
        {
            throw new NotImplementedException();
        }
    }
}
