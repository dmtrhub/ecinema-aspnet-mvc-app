using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ecinema_aspnet_mvc_app.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
    }
}
