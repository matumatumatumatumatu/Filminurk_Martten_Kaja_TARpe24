using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Models.Actors;

namespace Filminurk.Core.ServiceInterface
{
    public interface IActorsServices
    {
        Task<Actor> Create(ActorsDTO dto);
        Task<Actor> Delete(Guid id);
        Task<Actor> DetailsAsync(Guid id);
        Task<Actor> Update(ActorsDTO dto);
        Task<List<Actor>> GetAllActors();
    }
}