using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Filminurk.Core.Dto
{
    public class OmdbResultDTO
    {
        [JsonPropertyName("Response")]
        public string? Response { get; set; }
        [JsonPropertyName("Error")]
        public string? Error { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Released")]
        public string? Year { get; set; }


        [JsonPropertyName("Director")]
        public string? Director { get; set; }

        [JsonPropertyName("imdbRating")]
        public string? imdbRating { get; set; }
    }
}
