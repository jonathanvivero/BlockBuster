using BlockBuster.FILM.Film.Domain.FilmAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Persistence.Mapping
{
    public class FilmMap : IEntityTypeConfiguration<Domain.FilmAggregate.Film>
    {
        public void Configure(EntityTypeBuilder<Domain.FilmAggregate.Film> builder)
        {
            builder.ToTable("film");

            builder.Property(p => p.Id)
               .HasColumnName("id")
               .HasColumnType("nvarchar(40)")
               .HasConversion(
                   v => v.GetValue(),
                   v => new FilmId(v)
               ).IsRequired();

            builder.Property(p => p.CategoryId)
               .HasColumnName("category_id")
               .HasColumnType("nvarchar(40)")
               .HasConversion(
                   v => v.GetValue(),
                   v => new FilmCategoryId(v)
               ).IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(256)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmName(v)
                ).IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(512)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmDescription(v)
                ).IsRequired();
            
            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmCreatedAt(v)
                ).IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmUpdatedAt(v)
                ).IsRequired();

            builder.Ignore(i => i.Category);
        }
    }
}
