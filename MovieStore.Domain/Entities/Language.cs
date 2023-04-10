using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public class Language : IBaseEntity
    {
        public Language()
        {
            OriginalLanguageOfMovies = new List<Movie>();
        }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public Status Statu { get; set; }

        //Navigation Property
        public List<Movie>? OriginalLanguageOfMovies { get; set; }
        //public List<Movie>? SubtitleLanguageOfMovies { get; set; }
    }
}