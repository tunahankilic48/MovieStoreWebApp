using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public class Starring : IBaseEntity
    {
        public Starring()
        {
            PerformedMovies = new List<Movie>();
        }

        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu { get; set; }


        //Navigation Property
        public List<Movie>? PerformedMovies { get; set; }

        //Not Mapped
        public string FullName => FirstName + " " + LastName;

    }
}