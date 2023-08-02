using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Models;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}
