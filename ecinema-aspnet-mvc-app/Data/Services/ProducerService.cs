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
        public void Add(Producer producer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var producers = await _context.Producers.ToListAsync();
            return producers;
        }

        public Producer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Producer Update(int id, Producer newProducer)
        {
            throw new NotImplementedException();
        }
    }
}
