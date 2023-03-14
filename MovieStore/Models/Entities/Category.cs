namespace MovieStore.Models.Entities
{
    public class Category
    {
        public Category()
        {
            Movies = new List<Movie>();
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }


        //Navigation Property
        public List<Movie>? Movies { get; set; }
    }
}