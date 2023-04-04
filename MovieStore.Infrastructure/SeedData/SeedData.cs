using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Infrastructure.SeedData
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();

                List<Category> generatedCategories = new List<Category>();
                List<Starring> generatedStarrings = new List<Starring>();
                List<Director> generatedDirectors = new List<Director>();
                List<Language> generatedLanguages = new List<Language>();
                List<Movie> generatedMovies = new List<Movie>();
                if (!context.Categories.Any())
                {
                    var categoryFaker = new Faker<Category>()
                        .RuleFor(x => x.Name, y => y.Lorem.Word())
                        .RuleFor(x => x.Description, y => y.Lorem.Sentence(2))
                        .RuleFor(x => x.Statu, Status.Active);
                        
                    

                    generatedCategories = categoryFaker.Generate(15);

                    context.Categories.AddRange(generatedCategories);
                    context.SaveChanges();

                }

                if (!context.Starrings.Any())
                {
                    var starringFaker = new Faker<Starring>()
                        .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                        .RuleFor(x => x.LastName, y => y.Name.LastName())
                        .RuleFor(x => x.BirthDate, y => y.Person.DateOfBirth)
                        .RuleFor(x => x.Statu, Status.Active);

                    generatedStarrings = starringFaker.Generate(25);
                    context.Starrings.AddRange(generatedStarrings);
                    context.SaveChanges();
                }

                if (!context.Directors.Any())
                {
                    var directorFaker = new Faker<Director>()
                        .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                        .RuleFor(x => x.LastName, y => y.Name.LastName())
                        .RuleFor(x => x.BirthDate, y => y.Person.DateOfBirth)
                        .RuleFor(x => x.Statu, Status.Active);

                    generatedDirectors = directorFaker.Generate(25);
                    context.Directors.AddRange(generatedDirectors);
                    context.SaveChanges();

                }

                //ToDo: Seed data eklenirkenki karakter htasını çöz

                if (!context.Languages.Any())
                {
                    var languageFaker = new Faker<Language>()
                        .RuleFor(x => x.Name, y => y.Vehicle.Model())
                        .RuleFor(x => x.Statu, Status.Active);

                    generatedLanguages = languageFaker.Generate(30);
                    context.Languages.AddRange(generatedLanguages);
                    context.SaveChanges();
                }


                if (!context.Movies.Any())
                {
                    var movieFaker = new Faker<Movie>()
                       .RuleFor(x => x.Name, y => y.Company.CompanyName())
                       .RuleFor(x => x.Description, y => y.Lorem.Sentences())
                       .RuleFor(x => x.Category, y => y.PickRandom(context.Categories.ToList()))
                       .RuleFor(x => x.Director, y => y.PickRandom(context.Directors.ToList()))
                       .RuleFor(x => x.ReleaseDate, y => y.Date.Between(new DateTime(1900, 01, 01), new DateTime(2023, 03, 19)))
                       .RuleFor(x => x.RunningTimeMin, y => y.Random.Number(1000))
                       .RuleFor(x => x.Language, y => y.PickRandom(context.Languages.ToList()))
                       .RuleFor(x => x.Price, y => y.Random.Number(99999))
                       .RuleFor(x => x.Stock, y => y.Random.Number(1000))
                       .RuleFor(x => x.IsActive, y => y.Random.Bool())
                       .RuleFor(x => x.Starrings, y => y.PickRandomParam(context.Starrings.ToList()))
                       .RuleFor(x => x.Statu, Status.Active);


                    generatedMovies = movieFaker.Generate(40);
                    context.Movies.AddRange(generatedMovies);
                    context.SaveChanges();
                }
            }
        }
    }
}
