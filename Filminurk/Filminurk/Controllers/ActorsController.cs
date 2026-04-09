using Filminurk.ApplicationServices.Services;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Filminurk.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IActorsServices _actorServices;

        public ActorsController(FilminurkTARpe24Context context, IActorsServices actorServices)
        {
            _context = context;
            _actorServices = actorServices;
        }

        public IActionResult Index()
        {
            var result = _context.Actors.Select(x => new ActorsIndexViewModel
            {
                ActorID = x.ActorID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Nationality = (Nationality)x.Nationality
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUpdate", new ActorsCreateUpdateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorsCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new ActorsDTO
            {
                ActorID = vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                Age = vm.Age,
                Nationality = (Core.Domain.Nationality)vm.Nationality,
                IsActive = vm.IsActive,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
                MoviesActedFor = vm.MoviesActedFor
            };

            var result = await _actorServices.Create(dto);
            if (result == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);
            if (actor == null) return NotFound();

            var vm = new ActorsDetailsViewModel
            {
                ActorID = actor.ActorID,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                NickName = actor.NickName,
                Age = actor.Age,
                Nationality = (Nationality)actor.Nationality,
                IsActive = actor.IsActive ?? false,
                EntryCreatedAt = actor.EntryCreatedAt,
                EntryModifiedAt = actor.EntryModifiedAt,
                MoviesActedFor = actor.MoviesActedFor
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);
            if (actor == null) return NotFound();

            var vm = new ActorsCreateUpdateViewModel
            {
                ActorID = actor.ActorID,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                NickName = actor.NickName,
                Age = actor.Age,
                Nationality = (Nationality)actor.Nationality,
                IsActive = actor.IsActive ?? false,
                EntryCreatedAt = actor.EntryCreatedAt,
                EntryModifiedAt = actor.EntryModifiedAt,
                MoviesActedFor = actor.MoviesActedFor
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActorsCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new ActorsDTO
            {
                ActorID = vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                Age = vm.Age,
                Nationality = (Core.Domain.Nationality)vm.Nationality,
                IsActive = vm.IsActive,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
                MoviesActedFor = vm.MoviesActedFor
            };

            var result = await _actorServices.Update(dto);
            if (result == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);
            if (actor == null) return NotFound();

            var vm = new ActorsDeleteViewModel
            {
                ActorID = actor.ActorID,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                NickName = actor.NickName,
                Age = actor.Age,
                Nationality = (Nationality)actor.Nationality,
                IsActive = actor.IsActive ?? false,
                EntryCreatedAt = actor.EntryCreatedAt,
                EntryModifiedAt = actor.EntryModifiedAt,
                MoviesActedFor = actor.MoviesActedFor
            };

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var actor = await _actorServices.Delete(id);
            if (actor == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}