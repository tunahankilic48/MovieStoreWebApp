using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Infrastructure.SeedData
{
    public class SeedData
    {
        public async static Task Seed(IApplicationBuilder app)
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
                        .RuleFor(x => x.Name, y => y.Commerce.ProductName())
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
                       .RuleFor(x => x.Statu, Status.Active)
                       .RuleFor(x => x.ImagePath, y => y.Image.PicsumUrl(600, 560));


                    generatedMovies = movieFaker.Generate(40);
                    context.Movies.AddRange(generatedMovies);
                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    await roleStore.CreateAsync(new IdentityRole() { Name = "Admin" , NormalizedName = "Admin" });
                    await roleStore.CreateAsync(new IdentityRole() { Name = "Manager" , NormalizedName = "Manager" });
                    await roleStore.CreateAsync(new IdentityRole() { Name = "Customer", NormalizedName = "Customer"});
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                   var passwordHasher = new PasswordHasher<AppUser>();

                    AppUser adminUser = new AppUser
                    {
                        UserName = "admn1",
                        NormalizedUserName = "admn1",
                        Email = "admin@gmail.com",
                        ImagePath = "/images/noImage.png",
                        Statu = Status.Active,

                    };

                    var hashed = passwordHasher.HashPassword(adminUser, "1234");
                    adminUser.PasswordHash = hashed;

                    var userStore = new UserStore<AppUser>(context);
                    
                    await userStore.CreateAsync(adminUser);
                    await userStore.AddToRoleAsync(adminUser, "Admin");
                    await context.SaveChangesAsync();


                    AppUser customerUser = new AppUser
                    {
                        UserName = "customer",
                        NormalizedUserName ="customer",
                        Email = "customer@gmail.com",
                        ImagePath = "/images/noImage.png",
                        Statu = Status.Active,
                    };

                    var hashedCustomer = passwordHasher.HashPassword(customerUser, "1234");
                    customerUser.PasswordHash = hashedCustomer;

                    var customerStore = new UserStore<AppUser>(context);

                    await userStore.CreateAsync(customerUser);
                    await userStore.AddToRoleAsync(customerUser, "Customer");
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
