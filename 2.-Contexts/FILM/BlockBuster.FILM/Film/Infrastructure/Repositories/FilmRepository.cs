using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Repositories
{
    public class FilmRepository : Repository<Domain.FilmAggregate.Film>, IFilmRepository
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public FilmRepository(IBlockBusterFilmContext context,
            IServiceScopeFactory serviceScopeFactory)
            : base(context)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public Domain.FilmAggregate.Film FindByName(FilmName name)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Films
                    .FirstOrDefault(w => w.Name.GetValue() == name.GetValue());
            }

        }
        public Domain.FilmAggregate.Film FindById(FilmId id)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Films
                    .FirstOrDefault(w => w.Id.GetValue() == id.GetValue());
            }
        }
        public IEnumerable<Domain.FilmAggregate.Film> GetAllFilms(IDictionary<string, int> page)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext.Films
                    .Skip((page["number"] - 1) * page["size"])
                    .Take(page["size"]); ;
            }
        }
        public override void Add(Domain.FilmAggregate.Film film)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                dbContext
                    .Films
                    .Add(film);
            }
        }
    }
}
