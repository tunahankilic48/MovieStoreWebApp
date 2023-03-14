namespace MovieStore.Models.Entities
{
    public class Starring
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        //Navigation Property
        public List<Movie> PerformedMovies { get; set; }
    }
}