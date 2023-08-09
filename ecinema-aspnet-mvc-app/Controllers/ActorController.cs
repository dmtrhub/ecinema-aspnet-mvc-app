using ecinema_aspnet_mvc_app.Data;
using ecinema_aspnet_mvc_app.Data.Services;
using ecinema_aspnet_mvc_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace ecinema_aspnet_mvc_app.Controllers
{
    [Authorize]
    public class ActorController : Controller
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actors = await _service.GetAllAsync();
            return View(actors);
        }

        // GET: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction("Index");
        }

        // GET: Actor/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null)
                return View("Empty");
            return View(details);
        }

        // GET: Actor/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _service.GetByIdAsync(id);
            if (edit == null)
                return View("NotFound");
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction("Index");
        }

        // GET: Actor/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if(delete == null)
                    return View("NotFound");
            return View(delete);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = await _service.GetByIdAsync(id);
            if(delete == null)
            {
                return View("NotFound");
            } 

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
