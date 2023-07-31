using ecinema_aspnet_mvc_app.Data;
using ecinema_aspnet_mvc_app.Data.Services;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAllAsync();
            return View(cinemas);
        }

        // GET: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction("Index");
        }

        // GET: Cinema/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
                return View("Empty");
            return View(details);
        }

        // GET: Cinema/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _service.GetByIdAsync(id);
            if (edit == null)
                return View("Not Found");
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction("Index");
        }

        // GET: Cinema/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if (delete == null)
                return View("Not Found");
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if (delete == null)
            {
                return View("Not Found");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
