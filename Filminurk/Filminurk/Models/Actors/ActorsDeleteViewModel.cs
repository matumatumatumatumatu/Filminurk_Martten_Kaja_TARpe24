using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.Actors
{
    public class ActorsDeleteViewModel
    {
        [Key]
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public List<string> MoviesActedFor { get; set; }
        public int? PortraitID { get; set; }

        public int? Age { get; set; }
        public Nationality Nationality { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
