using ecinema_aspnet_mvc_app.Data;
using ecinema_aspnet_mvc_app.Data.Services;
using ecinema_aspnet_mvc_app.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllAsync(c => c.Cinema);
            return View(movies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string search)
        {
            var movies = await _service.GetAllAsync(c => c.Cinema);

            if (!string.IsNullOrEmpty(search))
            {
                var filter = movies.Where(m => string.Equals(m.Title, search, StringComparison.CurrentCultureIgnoreCase) || string.Equals(m.Description, search, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filter);
            }

            return View("Index", movies);
        }

        //GET: Movie/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);
            return View(details);
        }

        //GET: Movie/Create
        public async Task<IActionResult> Create()
        {
            var dropdown = await _service.GetNewMovieDropdowns();

            ViewBag.Cinemas = new SelectList(dropdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropdown.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var dropdown = await _service.GetNewMovieDropdowns();

                ViewBag.Cinemas = new SelectList(dropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropdown.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movie/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);
            if (details == null)
                return View("NotFound");

            var result = new NewMovieVM()
            {
                Id = details.Id,
                Title = details.Title,
                Description = details.Description,
                Price = details.Price,
                StartDate = details.StartDate,
                EndDate = details.EndDate,
                PictureUrl = details.PictureUrl,
                Category = details.Category,
                CinemaId = details.CinemaId,
                ProducerId = details.ProducerId,
                ActorIds = details.Movie_Actors.Select(a => a.ActorId).ToList(),
            };

            var dropdowns = await _service.GetNewMovieDropdowns();
            ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dropdowns = await _service.GetNewMovieDropdowns();

                ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        // GET: Movie/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null)
                return View("NotFound");
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
