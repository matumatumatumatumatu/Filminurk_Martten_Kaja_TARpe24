using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filminurk.Core.Domain;
using Filminurk.Core.Dto;

namespace Filminurk.Core.ServiceInterface
{
    public interface IMovieServices // see on interface, asub .core
    {
        Task<Movie> Create(MoviesDTO dto);
        Task<Movie> DetailsAsync(Guid id);
    };
       [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            if (result == null) { return NotFound(); }

            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();

            return (IActionResult)result;
        }
}
