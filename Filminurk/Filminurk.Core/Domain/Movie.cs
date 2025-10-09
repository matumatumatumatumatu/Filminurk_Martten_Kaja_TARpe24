using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
{        public enum Genre
        {
            Horror,Drama,Comedy,Action,Superhero,Romance,AISlop,Documentary
        }
    public class Movie
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public string Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        public decimal? RottenTomatoes { get; set; }
        public Genre Genre { get; set; }
        public int? OscarsWon { get; set; }
    }
}
