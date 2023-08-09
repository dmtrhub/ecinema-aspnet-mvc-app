using ecinema_aspnet_mvc_app.Data;
using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Data.Services;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Controllers
{
    [Authorize]
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAllAsync();
            return View(producers);
        }

        // GET: Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction("Index");
        }

        // GET: Producer/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
                return View("Empty");
            return View(details);
        }

        // GET: Producer/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _service.GetByIdAsync(id);
            if (edit == null)
                return View("NotFound");
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction("Index");
        }

        // GET: Producer/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if (delete == null)
                return View("NotFound");
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if (delete == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
