using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context) { }
    }
}
