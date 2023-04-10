using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStore.Domain.Entities;
using MovieStore.Infrastructure.EntityTypeConfig;

namespace MovieStore.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Starring> Starrings { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfig())
                        .ApplyConfiguration(new CategoryConfig())
                        .ApplyConfiguration(new DirectorConfig())
                        .ApplyConfiguration(new LanguageConfig())
                        .ApplyConfiguration(new StarringConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}
