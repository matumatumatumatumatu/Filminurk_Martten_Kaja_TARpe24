namespace Filminurk.Models.Movies
{
    public enum Genre
    {
        Horror, Drama, Comedy, Action, Superhero, Romance, AISlop, Documentary
    }
    public class MoviesIndexViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public DateOnly FirstPublished { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }
        public Genre Genre { get; set; }
    }
}
