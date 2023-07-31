using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            _context.Actors.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
