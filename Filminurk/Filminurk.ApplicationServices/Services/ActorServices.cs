using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.ApplicationServices.Services
{
    public class ActorServices : IActorServices
    {
        private readonly FilminurkTARpe24Context _context;

        public ActorServices(FilminurkTARpe24Context context)
        {
            _context = context;
        }

        public async Task<Actor> Create(ActorsDTO dto)
        {
            Actor actor = new Actor
            {
                ActorID = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PortraitID = dto.PortraitID,
                Age = dto.Age,
                Nationality = dto.Nationality,
                EntryCreatedAt = DateTime.UtcNow
            };

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> DetailsAsync(Guid id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.ActorID == id);
        }

        public async Task<Actor> Update(ActorsDTO dto)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ActorID == dto.ActorID);
            if (actor == null)
                throw new KeyNotFoundException("Actor not found");

            actor.FirstName = dto.FirstName;
            actor.LastName = dto.LastName;
            actor.PortraitID = dto.PortraitID;
            actor.Age = dto.Age;
            actor.Nationality = dto.Nationality;
            actor.EntryModifiedAt = DateTime.UtcNow;

            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> Delete(Guid id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ActorID == id);
            if (actor == null)
                throw new KeyNotFoundException("Actor not found");

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            return await _context.Actors.ToListAsync();
        }
    }
}}
