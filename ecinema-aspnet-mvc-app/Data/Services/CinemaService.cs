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
        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Cinemas.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return cinemas;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            return cinema;
        }

        public async Task<Cinema> UpdateAsync(int id, Cinema newCinema)
        {
            _context.Update(newCinema);
            await _context.SaveChangesAsync();
            return newCinema;
        }
    }
}
