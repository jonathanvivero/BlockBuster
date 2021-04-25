using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster.FILM.Category.Infrastructure.Repositories
{
    public class CategoryRepository: Repository<Domain.FilmAggregate.Category>, ICategoryRepository
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public CategoryRepository(IBlockBusterFilmContext context,
            IServiceScopeFactory serviceScopeFactory)
            : base(context)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Domain.FilmAggregate.Category FindById(CategoryId id)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Categories
                    .FirstOrDefault(w => w.Id.GetValue() == id.GetValue());
            }
        }

        public Domain.FilmAggregate.Category FindByName(CategoryName name)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Categories
                    .FirstOrDefault(w => w.Name.GetValue() == name.GetValue());
            }
        }

        public IEnumerable<Domain.FilmAggregate.Category> GetAllCategories()
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterFilmContext>();
                return dbContext
                    .Categories;
            }
        }
    }
}
