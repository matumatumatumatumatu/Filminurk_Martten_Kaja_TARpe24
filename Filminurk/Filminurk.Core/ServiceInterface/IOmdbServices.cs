using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IOmdbServices
    {
        Task<OmdbResultDTO> SearchMovieAsync(string title);
        Task<Movie> ImportMovieAsync(OmdbResultDTO dto);
    }
}
