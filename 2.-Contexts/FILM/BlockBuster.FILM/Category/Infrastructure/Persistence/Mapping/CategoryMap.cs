using BlockBuster.FILM.Category.Domain.FilmAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockBuster.FILM.Category.Infrastructure.Persistence.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Domain.FilmAggregate.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.FilmAggregate.Category> builder)
        {
            builder.ToTable("category");

            builder.Property(p => p.Id)
               .HasColumnName("id")
               .HasColumnType("nvarchar(40)")
               .HasConversion(
                   v => v.GetValue(),
                   v => new CategoryId(v)
               ).IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(64)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryName(v)
                ).IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryCreatedAt(v)
                ).IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryUpdatedAt(v)
                ).IsRequired();
        }
    }
}
