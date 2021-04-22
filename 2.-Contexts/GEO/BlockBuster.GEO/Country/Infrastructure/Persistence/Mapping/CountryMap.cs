using BlockBuster.GEO.Country.Domain.CountryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockBuster.GEO.Country.Infrastructure.Presistence.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<Domain.CountryAggregate.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.CountryAggregate.Country> builder)
        {
            builder.ToTable("country");

            builder.Property(p => p.Id)
               .HasColumnName("id")
               .HasColumnType("nvarchar(40)")
               .HasConversion(
                   v => v.GetValue(),
                   v => new CountryId(v)
               ).IsRequired();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasColumnType("nvarchar(3)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryCode(v)
                ).IsRequired();

            builder.Property(p => p.Tax)
                .HasColumnName("tax")
                .HasColumnType("double")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryTax(v)
                ).IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryCreatedAt(v)
                ).IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryUpdatedAt(v)
                ).IsRequired();
        }
    }
}
