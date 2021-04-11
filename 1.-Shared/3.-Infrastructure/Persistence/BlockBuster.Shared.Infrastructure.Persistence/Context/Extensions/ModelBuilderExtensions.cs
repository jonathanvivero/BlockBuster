using BlockBuster.Shared.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Persistence.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed<TContext>(this ModelBuilder modelBuilder, SeedChannel<TContext>[] seedList)
        {

            if (seedList.Length > 0)
            {
                foreach (SeedChannel<TContext> seedChannel in seedList)
                {
                    seedChannel.SeedDatabase();
                }
            }

            ///TODO: Create system for seed new data over new versions.

            //modelBuilder.Entity<Configuration>().HasData(
            //    new Configuration
            //    {
            //        AuthorId = 1,
            //        FirstName = "William",
            //        LastName = "Shakespeare"
            //    }
            //);
            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
            //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
            //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
            //);
        }
    }
}
