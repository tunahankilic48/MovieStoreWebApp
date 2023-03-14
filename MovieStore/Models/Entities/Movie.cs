using Microsoft.AspNetCore.Mvc.Razor;

namespace MovieStore.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public int DirectorId { get; set; }
        public decimal Price { get; set; }
        public int RunningTimeMin { get; set; }
        public int LanguageId { get; set; }




        // Navigaton Property
        public Category Category { get; set; }
        public Director Director { get; set; }
        public List<Starring> Starrings { get; set; }
        public Language Language { get; set; }
        public List<Language> SubtitleLanguages { get; set; }


    }
}
