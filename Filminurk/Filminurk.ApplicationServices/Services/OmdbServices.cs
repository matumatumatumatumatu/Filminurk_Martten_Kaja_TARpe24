using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Filminurk.ApplicationServices.Services
{
    public class OmdbServices : IOmdbServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly FilminurkTARpe24Context _context;

        public OmdbServices
        (
            IConfiguration configuration,
            FilminurkTARpe24Context context
        )
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _context = context;
        }

        public async Task<OmdbResultDTO> SearchMovieAsync(string title)
        {
            var apiKey = _configuration["OmdbApi:ApiKey"];
            var url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(title)}&apikey={apiKey}";
            var result = await _httpClient.GetFromJsonAsync<OmdbResultDTO>(url);

            return result ?? new OmdbResultDTO { Response = "False", Error = "No result" };
        }

        public async Task<Movie> ImportMovieAsync(OmdbResultDTO dto)
        {
            DateOnly firstPublished = DateOnly.MinValue;
            if (!string.IsNullOrEmpty(dto.Year))
            {
                if (DateOnly.TryParse(dto.Year, out var parsed))
                    firstPublished = parsed;
            }

            double? rating = null;
            if (double.TryParse(dto.imdbRating,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out var parsedRating))
            {
                rating = parsedRating;
            }

            var movie = new Movie
            {
                ID = Guid.NewGuid(),
                Title = dto.Title ?? "Unknown",
                Description = "",
                Director = dto.Director ?? "Unknown",
                FirstPublished = firstPublished,
                CurrentRating = rating,
                EntryCreatedAt = DateTime.Now,
                EntryModifiedAt = DateTime.Now,
                Genre = Genre.Drama,
                Reviews = new List<UserComment>()
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
    }
}