using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Models.Entities;

namespace MovieStore.Models.DataAccess.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1)
                .HasColumnOrder(1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasColumnOrder(2);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true)
                .HasColumnOrder(3);
        }
    }
}
