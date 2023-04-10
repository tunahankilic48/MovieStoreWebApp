using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Infrastructure.EntityTypeConfig
{
    public class DirectorConfig : BaseEntityConfig<Director>
    {
        
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnOrder(2);


            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasColumnOrder(3);

            builder.Property(x => x.BirthDate)
                .HasColumnType("date")
                .HasColumnOrder(4);

            base.Configure(builder);
        }
    }
}
