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
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly FilmRepositoryFilterBuilder _filmRepositoryFilterBuilder;
        public FilmRepository(IBlockBusterFilmContext context,
            IServiceScopeFactory serviceScopeFactory,
            FilmRepositoryFilterBuilder filmRepositoryFilterBuilder)
            : base(context)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _filmRepositoryFilterBuilder = filmRepositoryFilterBuilder;
        }
        public Domain.FilmAggregate.Film FindByName(FilmName name)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Films
                    .FirstOrDefault(w => w.Name.GetValue() == name.GetValue());
            }

        }
        public Domain.FilmAggregate.Film FindById(FilmId id)
        {
            using (var scope = this._serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Films
                    .FirstOrDefault(w => w.Id.GetValue() == id.GetValue());
            }
        }
        public IEnumerable<Domain.FilmAggregate.Film> GetAllFilms(
            IDictionary<string, int> page,
            IDictionary<string, string[]> filter)
        {
            var predicate = _filmRepositoryFilterBuilder.BuildFilter(filter);
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext.Films
                    .Where(predicate)
                    .Skip((page["number"] - 1) * page["size"])
                    .Take(page["size"]); ;
            }
        }
        public override void Add(Domain.FilmAggregate.Film film)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                dbContext
                    .Films
                    .Add(film);
            }
        }
    }
}
