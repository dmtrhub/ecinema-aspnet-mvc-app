using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class ProducerService : IProducerService
    {
        private readonly AppDbContext _context;

        public ProducerService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);
            _context.Producers.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var producers = await _context.Producers.ToListAsync();
            return producers;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);
            return producer;
        }

        public async Task<Producer> UpdateAsync(int id, Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
            return newProducer;
        }
    }
}
