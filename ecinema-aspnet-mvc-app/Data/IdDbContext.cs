using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Data
{
    public class IdDbContext : IdentityDbContext
    {
        public IdDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserIdentityConfiguration());
        }
    }
}
