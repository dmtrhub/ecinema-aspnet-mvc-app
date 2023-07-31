using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllAsync();

        Task<Producer> GetByIdAsync(int id);

        Task AddAsync(Producer producer);

        Task<Producer> UpdateAsync(int id, Producer newProducer);

        Task DeleteAsync(int id);
    }
}
