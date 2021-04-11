using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Presistence.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserId(v)
                ).IsRequired();            

            builder.Property(p => p.CountryId)
                            .HasColumnName("country_id")
                            .HasColumnType("nvarchar(40)")
                            .HasConversion(
                                v => v.GetValue(),
                                v => new CountryId(v)
                            ).IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar(60)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserEmail(v)
                ).IsRequired();

            builder.Property(p => p.HashedPassword)
                .HasColumnName("password")
                .HasColumnType("nvarchar(100)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserHashedPassword(v)
                ).IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar(15)")
                .HasConversion(
                   v => v.GetValue(),
                   v => new UserFirstName(v)
                ).IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserLastName(v)
                ).IsRequired();


            builder.Property(p => p.Role)
                .HasColumnName("role")
                .HasColumnType("nvarchar(20)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserRole(v)
                ).IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("country_code")
                .HasColumnType("nvarchar(3)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserCountry(v)
                ).IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserCreatedAt(v)
                ).IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserUpdatedAt(v)
                ).IsRequired();

            builder.Ignore(p => p.Country);                
        }


    }
}
