using BlockBuster.FILM.Category.Infrastructure.Persistence.Mapping;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Mapping;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Seed;
using BlockBuster.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlockBuster.FILM.Film.Infrastructure.Persistence.Context
{
    public class BlockBusterFilmContext: 
            BlockBusterContext<IBlockBusterFilmContext>,
            IBlockBusterFilmContext
    {
        private readonly IServiceProvider _serviceProvider;
        public BlockBusterFilmContext(DbContextOptions<BlockBusterFilmContext> options,
            IServiceProvider serviceProvider)
            : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        public DbSet<Domain.FilmAggregate.Film> Films { get; set; }
        public DbSet<Category.Domain.FilmAggregate.Category> Categories { get; set; }
        protected override void SetEntityModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }

        protected override void SetUpDatabaseSeeding()
        {
            _seedList.Add(_serviceProvider.GetService<SeedFilms>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        protected virtual void Dispose(bool cond)
        {
            //context.Dispose();
            GC.SuppressFinalize(this);
        }

        public new void Dispose()
        {
            this.Dispose(true);
        }
    }
}
