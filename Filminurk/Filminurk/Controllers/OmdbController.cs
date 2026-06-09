using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class OmdbController : Controller
    {
        private readonly IOmdbServices _omdbServices;

        public OmdbController(IOmdbServices omdbServices)
        {
            _omdbServices = omdbServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ModelState.AddModelError("", "Palun sisesta filmi nimi.");
                return View("Index");
            }

            var result = await _omdbServices.SearchMovieAsync(title);

            if (result.Response == "False")
            {
                ViewBag.Error = result.Error ?? "Filmi ei leitud.";
                return View("Index");
            }

            var movie = await _omdbServices.ImportMovieAsync(result);
            return RedirectToAction("Details", "Movies", new { id = movie.ID });
        }
    }
}