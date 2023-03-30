using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Domain.Entities;

namespace MovieStore.Infrastructure.EntityTypeConfig
{
    public class LanguageConfig : BaseEntityConfig<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnOrder(2);

            base.Configure(builder);
        }
    }
}
