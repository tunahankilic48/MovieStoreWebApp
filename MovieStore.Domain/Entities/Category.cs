using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            Movies = new List<Movie>();
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Status Statu { get; set; }


        //Navigation Property
        public List<Movie>? Movies { get; set; }
    }
}