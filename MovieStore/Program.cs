using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Seed;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection string will be taken from appsettings.json file

builder.Services.AddScoped<IMovieDbContext, MovieDbContext>(); // The program create MovieDbContext Object when encounter IMovieDbContext Interface


//builder.Services.AddTransient<IMovieRepository, MovieRepository>()
//                .AddTransient<ICategoryRepository, CategoryRepository>()
//                .AddTransient<IDirectorRepository, DirectorRepository>()
//                .AddTransient<IStarringRepository, StarringRepository>()
//                .AddTransient<ILanguageRepository, LanguageRepository>();

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Seed datalarý dbye eklemek için yazdýk
SeedData.Seed(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
