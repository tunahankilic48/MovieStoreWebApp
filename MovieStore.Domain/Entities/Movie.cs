using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public class Movie : IBaseEntity
    {
        public Movie()
        {
            Starrings = new List<Starring>();
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? DirectorId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunningTimeMin { get; set; }
        public int? LanguageId { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool? IsActive { get; set; }
        public string? ImagePath{ get; set; }
        public Status Statu { get; set; }




        // Navigaton Property
        public Category? Category { get; set; }
        public Director? Director { get; set; }
        public List<Starring>? Starrings { get; set; }
        public Language? Language { get; set; }
        //public List<Language>? SubtitleLanguages { get; set; }

    }
}
