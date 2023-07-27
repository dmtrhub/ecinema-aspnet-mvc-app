using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAll();

        Producer GetById(int id);

        void Add(Producer producer);

        Producer Update(int id, Producer newProducer);

        void Delete(int id);
    }
}
