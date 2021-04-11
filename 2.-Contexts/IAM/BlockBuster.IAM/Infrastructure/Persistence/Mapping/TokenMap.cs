using BlockBuster.IAM.Domain.TokenAggregate;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Presistence.Mapping
{
    public class TokenMap : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("token");

            builder.Property(p => p.UserId)
               .HasColumnName("user_id")
               .HasColumnType("nvarchar(40)")
               .HasConversion(
                   v => v.GetValue(),
                   v => new TokenUserId(v)
               ).IsRequired();

            builder.Property(p => p.Hash)
                .HasColumnName("hash")
                .HasColumnType("nvarchar(255)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenHash(v)
                ).IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenCreatedAt(v)
                ).IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUpdatedAt(v)
                ).IsRequired();
        }
    }
}
