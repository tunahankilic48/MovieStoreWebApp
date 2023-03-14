using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Models.Entities;

namespace MovieStore.Models.DataAccess.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies"); // Table name will be Movies in the Database.

            builder.HasKey(x => x.Id); // Id is set as primary key.

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1) // Id starts at 1 and increase one by one
                .HasColumnOrder(1); // Id is the first column in the database

            builder.Property(x => x.Name)
                .IsRequired() // This makes it that is neccessary
                .HasMaxLength(50) // The maximum chracters can be 50
                .IsUnicode(true) // It accepts Unicode characters such as chinese alphabet
                .HasColumnOrder(2);

            builder.Property(x => x.CategoryId)
                .IsRequired()
                .HasColumnOrder(3);

            builder.Property(x => x.DirectorId)
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.ReleaseDate)
                .IsRequired()
                .HasColumnType("date") // Data Type is YYYY/MM/DD in the database
                .HasColumnOrder(5);

            builder.Property(x => x.RunningTimeMin)
                .HasColumnOrder(6)
                .HasColumnType("smallint");

            builder.Property(x => x.LanguageId)
                .IsRequired()
                .HasColumnOrder(7);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(7,2)")
                .HasColumnOrder(8);

            builder.Property(x => x.Stock)
                .IsRequired()
                .HasColumnOrder(9);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(false) // Default value is fals. If there is no input, the value of the property will be false
                .HasColumnOrder(10);

            // Foreign Key Between Movie and Category
            builder.HasOne<Category>(x=>x.Category)
                .WithMany(x=>x.Movies)
                .HasForeignKey(x => x.CategoryId);

            // Foreign Key Between Movie and Director
            builder.HasOne<Director>(x => x.Director)
                .WithMany(x => x.DirectedMovies)
                .HasForeignKey(x => x.DirectorId);

            // Foreign Key Between Movie and Language
            builder.HasOne<Language>(x => x.Language)
                .WithMany(x => x.OriginalLanguageOfMovies)
                .HasForeignKey(x => x.LanguageId);

        }
    }
}
