using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Infrastructure.Persistence.Repository;
using LinqKit;
using System.Collections.Generic;

namespace BlockBuster.FILM.Film.Infrastructure.Repositories
{
    public class FilmRepositoryFilterBuilder: RepositoryFilterBuilder<Domain.FilmAggregate.Film>
    {
        public override ExpressionStarter<Domain.FilmAggregate.Film> BuildFilter(
            IDictionary<string, string[]> filter)
        {
            Add(filter, 
                FilmResources.QueryFieldName, 
                AddStringValueContainsPredicate, 
                "Name");

            Add(filter, 
                FilmResources.QueryFieldId, 
                AddStringValueEqualsPredicate, 
                "Id");

            return BuildAndReturn();
        }        
    }
}
