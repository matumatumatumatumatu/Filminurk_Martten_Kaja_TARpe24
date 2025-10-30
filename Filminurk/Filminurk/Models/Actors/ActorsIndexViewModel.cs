using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.Actors
{
    public enum Nationality
    {
        Estonian, Latvian, Lithuanian, Polish, German, French, Spanish, Portugese, Swiss, Austrian, Italian, Slovene, Croatian, Bosnian, Montegran, Macedonian, Serbian, Greek, Turk, Romanian, Bulgarian, Belarussian, Russian, Finnish, Swedish, Norwegian, Icelandic, British
    }
    public class ActorsIndexViewModel
    {
        [Key]
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public List<string> MoviesActedFor {  get; set; }
        public int? PortraitID { get; set; }

        public int? Age {  get; set; }
        public Nationality Nationality { get; set; }
        public bool? IsActive { get; set; }
    }
}
