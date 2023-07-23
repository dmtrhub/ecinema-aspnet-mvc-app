using ecinema_aspnet_mvc_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext _context;

        public ProducerController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Producers.ToListAsync();
            return View(data);
        }
    }
}
