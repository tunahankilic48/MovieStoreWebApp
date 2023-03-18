namespace MovieStore.Models.Entities
{
    public class Starring
    {
        public Starring()
        {
            PerformedMovies = new List<Movie>();
        }

        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }


        //Navigation Property
        public List<Movie>? PerformedMovies { get; set; }

        //Not Mapped
        public string FullName => FirstName + " " + LastName;
    }
}