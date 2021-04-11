using BlockBuster.IAM.Domain.TokenAggregate;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Presistence.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
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
                .HasColumnName("hash")
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
