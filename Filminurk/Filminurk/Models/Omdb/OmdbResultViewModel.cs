using Filminurk.Core.Domain;

namespace Filminurk.Models.Omdb
{
    public class OmdbResultViewModel
    {
         public string Title { get; set; }
        public DateOnly Year { get; set; }
        public Genre Genre { get; set; }
        public string Director { get; set; }
        public double? imdbRating { get; set; }

    }
}
