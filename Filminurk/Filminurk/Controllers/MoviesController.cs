using Filminurk.ApplicationServices.Services;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Filminurk.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IMovieServices _movieServices;
        private readonly IFileServices _filesServices;

        public MoviesController(FilminurkTARpe24Context context, IMovieServices movieServices, IFileServices filesServices)
        {
            _context = context;
            _movieServices = movieServices;
            _filesServices = filesServices;
        }

        public IActionResult Index()
        {
            var result = _context.Movies.Select(x => new MoviesIndexViewModel
            {
                ID = x.ID,
                Title = x.Title,
                FirstPublished = x.FirstPublished,
                CurrentRating = x.CurrentRating
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUpdate", new MoviesCreateUpdateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MoviesCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new MoviesDTO
            {
                ID = vm.ID,
                Title = vm.Title,
                Description = vm.Description,
                FirstPublished = vm.FirstPublished,
                CurrentRating = vm.CurrentRating,
                Director = vm.Director,
                Actors = vm.Actors,
                RottenTomatoes = vm.RottenTomatoes,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
                Files = vm.Files,
                FileToApiDTOs = vm.Images.Select(x => new FileToApiDTO
                {
                    ImageID = x.ImageID,
                    FilePath = x.FilePath,
                    MovieID = x.MovieID,
                    IsPoster = x.IsPoster
                }).ToArray()
            };

            var result = await _movieServices.Create(dto);
            if (result == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);
            if (movie == null) return NotFound();

            var images = await FileFromDatabase(id);

            var vm = new MoviesDetailsViewModel
            {
                ID = movie.ID,
                Title = movie.Title,
                Description = movie.Description,
                FirstPublished = movie.FirstPublished,
                CurrentRating = movie.CurrentRating,
                Director = movie.Director,
                Actors = movie.Actors,
                RottenTomatoes = movie.RottenTomatoes,
                EntryCreatedAt = movie.EntryCreatedAt,
                EntryModifiedAt = movie.EntryModifiedAt
            };
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);
            if (movie == null) return NotFound();

            var images = await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageID = y.ImageID,
                    MovieID = y.MovieID,
                    IsPoster = y.IsPoster
                }).ToArrayAsync();

            var vm = new MoviesCreateUpdateViewModel
            {
                ID = movie.ID,
                Title = movie.Title,
                Description = movie.Description,
                FirstPublished = movie.FirstPublished,
                CurrentRating = movie.CurrentRating,
                Director = movie.Director,
                Actors = movie.Actors,
                RottenTomatoes = movie.RottenTomatoes,
                EntryCreatedAt = movie.EntryCreatedAt,
                EntryModifiedAt = movie.EntryModifiedAt
            };
            vm.Images.AddRange(images);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MoviesCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new MoviesDTO
            {
                ID = vm.ID,
                Title = vm.Title,
                Description = vm.Description,
                FirstPublished = vm.FirstPublished,
                CurrentRating = vm.CurrentRating,
                Director = vm.Director,
                Actors = vm.Actors,
                RottenTomatoes = vm.RottenTomatoes,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
                Files = vm.Files,
                FileToApiDTOs = vm.Images.Select(x => new FileToApiDTO
                {
                    ImageID = x.ImageID,
                    FilePath = x.FilePath,
                    MovieID = x.MovieID,
                    IsPoster = x.IsPoster
                }).ToArray()
            };

            var result = await _movieServices.Update(dto);
            if (result == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);
            if (movie == null) return NotFound();

            var images = await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageID = y.ImageID,
                    MovieID = y.MovieID,
                    IsPoster = y.IsPoster
                }).ToArrayAsync();

            var vm = new MoviesDeleteVievModel
            {
                ID = movie.ID,
                Title = movie.Title,
                Description = movie.Description,
                FirstPublished = movie.FirstPublished,
                CurrentRating = movie.CurrentRating,
                Director = movie.Director,
                Actors = movie.Actors,
                RottenTomatoes = movie.RottenTomatoes,
                EntryCreatedAt = movie.EntryCreatedAt,
                EntryModifiedAt = movie.EntryModifiedAt
            };
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var movie = await _movieServices.Delete(id);
            if (movie == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        private async Task<ImageViewModel[]> FileFromDatabase(Guid id)
        {
            return await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new ImageViewModel
                {
                    ImageID = y.ImageID,
                    MovieID = y.MovieID,
                    FilePath = y.ExistingFilePath,
                    IsPoster = y.IsPoster
                }).ToArrayAsync();
        }
    }
}