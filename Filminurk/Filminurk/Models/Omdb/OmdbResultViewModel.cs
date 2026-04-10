using Filminurk.Core.Domain;

namespace Filminurk.Models.Omdb
{
    public class OmdbResultViewModel
    {
         public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public double? imdbRating { get; set; }

    }
}
